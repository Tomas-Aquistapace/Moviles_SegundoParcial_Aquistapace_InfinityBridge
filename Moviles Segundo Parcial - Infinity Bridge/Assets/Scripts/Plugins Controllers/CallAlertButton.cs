﻿using UnityEngine;

public class CallAlertButton : MonoBehaviour
{
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ShowAlert()
    {
        string[] strings = { "Alert Android Window", "Alert Message", "Close"};
        PluginsManager.GetLogger().ShowAlertView(strings, (int obj) => {
            Debug.Log("Local handler called: " + obj);
        });

        PluginsManager.GetLogger().SendLog("Se llama a la ventana");
    }
}
