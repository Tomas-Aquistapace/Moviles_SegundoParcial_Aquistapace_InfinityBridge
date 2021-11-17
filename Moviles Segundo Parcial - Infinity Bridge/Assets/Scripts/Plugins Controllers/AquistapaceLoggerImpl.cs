using UnityEngine;

public class AquistapaceLoggerImpl : LoggerImpl
{
    const string PACK_NAME = "com.example.aquistapaceloggerplugin";
    const string LOGGER_CLASS_NAME = "ALogger";

    static AndroidJavaClass ALoggerClass = null;
    static AndroidJavaObject ALoggerInstance = null;

    public void Init()
    {
        ALoggerClass = new AndroidJavaClass(PACK_NAME + "." + LOGGER_CLASS_NAME);
        ALoggerInstance = ALoggerClass.CallStatic<AndroidJavaObject>("GetInstance");
    }

    public override void SendLog(string msg)
    {
        if (ALoggerInstance == null)
            Init();

        ALoggerInstance.Call("SendLog", msg);
    }
}
