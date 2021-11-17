using UnityEngine;

public class StandAloneLoggerImpl : LoggerImpl
{
    public void Init()
    {
        
    }

    public override void SendLog(string msg)
    {
        Debug.Log(msg);
    }
}
