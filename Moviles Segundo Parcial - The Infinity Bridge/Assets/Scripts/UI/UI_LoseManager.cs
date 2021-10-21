using UnityEngine;
using TMPro;

public class UI_LoseManager : MonoBehaviour
{
    [SerializeField] GameObject[] disableUI_Items;

    [SerializeField] GameObject loseScreen;

    [SerializeField] TextMeshProUGUI maxPoints;
    [SerializeField] TextMeshProUGUI newPoints;

    [SerializeField] PlayerState player;

    private void OnEnable()
    {
        PlayerState.LoseGame += EnableDeathBox;
    }

    private void OnDisable()
    {
        PlayerState.LoseGame -= EnableDeathBox;
    }

    void EnableDeathBox()
    {
        foreach (GameObject item in disableUI_Items)
        {
            item.SetActive(false);
        }

        loseScreen.SetActive(true);

        maxPoints.text = GetActualRecord().ToString();
        newPoints.text = player.points.ToString();
    }

    int GetActualRecord()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        return data.points;
    }
}
