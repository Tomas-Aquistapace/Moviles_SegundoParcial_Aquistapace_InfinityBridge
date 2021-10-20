using UnityEngine;
using TMPro;

public class UI_Points : MonoBehaviour
{    
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI livesText;

    private void Start()
    {
        pointsText.text = "0";
    }

    private void OnEnable()
    {
        PlayerState.EarnPoint += EarnPoint;
        PlayerState.LoseLives += UpgradeLives;
    }

    private void OnDisable()
    {
        PlayerState.EarnPoint -= EarnPoint;        
        PlayerState.LoseLives -= UpgradeLives;
    }

    void EarnPoint(int num)
    {
        pointsText.text = num.ToString();
    }

    void UpgradeLives(int num)
    {
        livesText.text = num.ToString();
    }

}
