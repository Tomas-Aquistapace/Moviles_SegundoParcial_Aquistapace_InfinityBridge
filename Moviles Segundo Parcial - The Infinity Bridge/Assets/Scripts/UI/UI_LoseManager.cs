using UnityEngine;
using TMPro;

public class UI_LoseManager : MonoBehaviour
{
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject pauseButton;

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
        loseScreen.SetActive(true);
        pauseButton.SetActive(false);

        maxPoints.text = GetActualRecord().ToString();
        newPoints.text = player.points.ToString();
    }

    int GetActualRecord()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        return data.points;
    }
}
