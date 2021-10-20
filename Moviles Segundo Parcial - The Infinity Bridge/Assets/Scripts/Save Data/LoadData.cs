using UnityEngine;

public class LoadData : MonoBehaviour
{
    private void Awake()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        AllPlayerData.SetActualRecord(data.points);
    }
}
