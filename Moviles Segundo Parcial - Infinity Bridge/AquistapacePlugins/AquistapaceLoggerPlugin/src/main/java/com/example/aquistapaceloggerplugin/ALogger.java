package com.example.aquistapaceloggerplugin;

import android.app.Activity;
import android.util.Log;

public class ALogger
{
    public static final ALogger _instance = new ALogger();

    public static ALogger GetInstance()
    {
        Log.d("La inst es: ", _instance.toString());
        return _instance;
    }

    public void SendLog(String msg)
    {
        Log.d("RL=>", msg);
    }

    public void SaveFile(Activity mainActivity)
    {

    }

    public void LoadFile()
    {

    }
}
