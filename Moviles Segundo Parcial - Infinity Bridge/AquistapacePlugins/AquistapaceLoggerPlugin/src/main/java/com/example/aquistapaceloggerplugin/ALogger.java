package com.example.aquistapaceloggerplugin;

import android.util.Log;

public class ALogger
{
    public static final ALogger _instance = new ALogger();

    public static ALogger GetInstance()
    {
        return _instance;
    }

    public void SendLog(String msg)
    {
        Log.d("RL=>", msg);
    }
}
