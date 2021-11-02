using UnityEngine;

public class LoadData : MonoBehaviour
{
    [SerializeField] private static int actualRecordPoints = 0;
    [SerializeField] private static int actualRecordCoins = 0;
    
    private void Awake()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        actualRecordPoints = data.points;
        actualRecordCoins = data.coins;
    }

    public static int GetActualRecord()
    {
        return actualRecordPoints;
    }
    
    public static int GetActualCoins()
    {
        return actualRecordCoins;
    }
}
