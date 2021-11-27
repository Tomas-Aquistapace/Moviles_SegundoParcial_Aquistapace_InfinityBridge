using UnityEngine;
using TMPro;

public class Android_CallAlertButton : MonoBehaviour
{
    public GameObject androidButton;
    public TextMeshProUGUI logScreen;

    private void Awake()
    {
#if UNITY_EDITOR || UNITY_ANDROID 
        androidButton.SetActive(true);
#elif UNITY_STANDALONE
        androidButton.SetActive(false);
#endif
    }

    public void ShowAlert()
    {
        string[] strings = { "Alert Android Window", "Alert Message", "Close"};
        PluginsManager.Get().GetLogger().ShowAlertView(strings, (int obj) => {
            Debug.Log("Local handler called: " + obj);
        });

        PluginsManager.Get().GetLogger().SendLog("Se llama a la ventana");
    }

    public void ShowLog()
    {
        logScreen.text = PluginsManager.Get().GetLogger().GetScore().ToString();
    }
}
