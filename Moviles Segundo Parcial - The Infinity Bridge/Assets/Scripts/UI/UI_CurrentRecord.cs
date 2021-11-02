using UnityEngine;
using TMPro;

public class UI_CurrentRecord : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentRecord;
    [SerializeField] TextMeshProUGUI currentCoins;

    private void Start()
    {
        currentRecord.text = LoadData.GetActualRecord().ToString();
        currentCoins.text = LoadData.GetActualCoins().ToString();
    }
}
