using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Points : MonoBehaviour
{    
    [SerializeField] TextMeshProUGUI pointsText;

    private void Start()
    {
        pointsText.text = "0";
    }

    private void OnEnable()
    {
        PlayerState.EarnPoint += EarnPoint;
    }

    private void OnDisable()
    {
        PlayerState.EarnPoint -= EarnPoint;        
    }

    void EarnPoint(int num)
    {
        pointsText.text = num.ToString();
    }

}
