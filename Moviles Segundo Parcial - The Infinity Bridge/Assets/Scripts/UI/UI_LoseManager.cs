using UnityEngine;
using TMPro;

public class UI_LoseManager : MonoBehaviour
{
    [Header("Disable Items")]
    [SerializeField] GameObject[] disableUI_Items;

    [Header("Lose Screen")]
    [SerializeField] GameObject loseScreen;

    [SerializeField] TextMeshProUGUI maxPoints;
    [SerializeField] TextMeshProUGUI newPoints;
    [SerializeField] TextMeshProUGUI actualCoins;

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

        actualCoins.text = GetActualCoins().ToString();
    }

    int GetActualRecord()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        return data.points;
    }

    int GetActualCoins()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        return player.coins + data.coins;
    }
}
