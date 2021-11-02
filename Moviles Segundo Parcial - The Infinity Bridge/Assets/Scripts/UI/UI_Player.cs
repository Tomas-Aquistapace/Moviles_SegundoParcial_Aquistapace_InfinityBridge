using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Player : MonoBehaviour
{    
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI coinsText;

    //[SerializeField] Image healthBar;
    //[SerializeField] LoseController player;

    //float health = 0;

    private void Start()
    {
        pointsText.text = "0";
        coinsText.text = "0";
        //health = 1 / (float)player.lives;
    }

    private void OnEnable()
    {
        PlayerState.EarnPoint += EarnPoint;
        PlayerState.EarnCoin += EarnCoin;
        //PlayerState.LoseLives += UpgradeLives;
    }

    private void OnDisable()
    {
        PlayerState.EarnPoint -= EarnPoint;
        PlayerState.EarnCoin -= EarnCoin;
        //PlayerState.LoseLives -= UpgradeLives;
    }

    void EarnPoint(int num)
    {
        pointsText.text = num.ToString();
    }
    
    void EarnCoin(int num)
    {
        coinsText.text = num.ToString();
    }

    //void UpgradeLives(int num)
    //{
    //    healthBar.fillAmount = health * num;
    //}
}
