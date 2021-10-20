using UnityEngine;

public class AllPlayerData : MonoBehaviour
{
    [SerializeField] private static int actualRecordPoints = 0;

    public static void SetActualRecord(int score)
    {
        actualRecordPoints = score;
    }

    public static int GetActualRecord()
    {
        return actualRecordPoints;
    }
}
