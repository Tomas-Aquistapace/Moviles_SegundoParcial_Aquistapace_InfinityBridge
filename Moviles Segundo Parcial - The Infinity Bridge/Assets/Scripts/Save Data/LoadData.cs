using UnityEngine;

public class LoadData : MonoBehaviour
{
    [SerializeField] private static int actualRecordPoints = 0;
    
    private void Awake()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        actualRecordPoints = data.points;
    }

    public static int GetActualRecord()
    {
        return actualRecordPoints;
    }
}
