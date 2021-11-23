using UnityEngine;

public class AquistapaceLoggerImpl : LoggerImpl
{
    const string PACK_NAME = "com.example.aquistapaceloggerplugin";
    const string POPUP_CLASS_NAME = "APopUp";

    class AlertViewCallback : AndroidJavaProxy
    {
        private System.Action<int> alertHandler;

        public AlertViewCallback(System.Action<int>alertHandlerIn) : base (PACK_NAME + "." + POPUP_CLASS_NAME + "$AlertViewCallback")
        {
            alertHandler = alertHandlerIn;
        }

        public void onButtonTapped(int index)
        {
            Debug.Log("Button tapped: " + index);
            if (alertHandler != null)
                alertHandler(index);
        }
    }

    static AndroidJavaClass APluginClass = null;
    static AndroidJavaObject APluginInstance = null;

    public static AndroidJavaClass PluginClass
    {
        get
        {
            if(APluginClass == null)
            {
                APluginClass = new AndroidJavaClass(PACK_NAME + "." + POPUP_CLASS_NAME);
                AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
                APluginClass.SetStatic<AndroidJavaObject>("mainActivity", activity);
            }
            return APluginClass;
        }
    }

    public static AndroidJavaObject PluginInstance
    {
        get
        {
            if (APluginInstance == null)
            {
                APluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
            return APluginInstance;
        }
    }

    public override void ShowAlertView(string[] strings, System.Action<int>handler = null)
    {
        if(strings.Length < 3)
        {
            Debug.LogError("AlertView requires at least 3 strings");
            return;
        }

        if (Application.platform == RuntimePlatform.Android)
            PluginInstance.Call("ShowAlertView", new object[] { strings, new AlertViewCallback(handler) });
        else
            Debug.LogWarning("AlertView not supported on this platform");
    }

    // --------------------------------------

    const string LOGGER_CLASS_NAME = "ALogger";

    static AndroidJavaClass ALoggerClass = null;
    static AndroidJavaObject ALoggerInstance = null;

    public void Init()
    {
        Debug.Log("Se crea: " + PACK_NAME + "." + LOGGER_CLASS_NAME);

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
