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

    public override void ShowAlertView(string[] strings, System.Action<int> handler = null)
    {

    }
}
