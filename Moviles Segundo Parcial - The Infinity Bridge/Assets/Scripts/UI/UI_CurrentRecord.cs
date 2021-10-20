using UnityEngine;
using TMPro;

public class UI_CurrentRecord : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentRecord;

    private void Start()
    {
        currentRecord.text = LoadData.GetActualRecord().ToString();
    }
}
