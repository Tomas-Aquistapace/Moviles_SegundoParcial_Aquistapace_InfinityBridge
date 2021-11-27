package com.example.aquistapaceloggerplugin;

import android.app.Activity;
import android.util.Log;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class ALogger
{
    public static final ALogger _instance = new ALogger();
    public static Activity activity;

    public static ALogger GetInstance()
    {
        Log.d("La inst es: ", _instance.toString());
        return _instance;
    }

    public void SendLog(String msg)
    {
        Log.d("RL=>", msg);
    }

    // -------------------------

    public void SaveScore(int score)
    {
        File path = activity.getFilesDir();
        File file = new File(path, "score.txt");

        try
        {
            FileOutputStream stream = new FileOutputStream(file);
            try
            {
                stream.write(Integer.toString(score).getBytes());
            }
            finally
            {
                stream.close();
            }
        }
        catch(IOException e)
        {
            Log.e("Exception", "Error: the file could not be recorded" + e.toString());
        }
    }

    public int GetScore()
    {
        File path = activity.getFilesDir();

        File file = new File(path, "score.txt");
        if (!file.exists())
            return 0;

        int length = (int) file.length();
        byte[] bytes = new byte[length];

        try
        {
            FileInputStream stream = new FileInputStream(file);
            try
            {
                stream.read(bytes);
            }
            finally
            {
                stream.close();
            }
        }
        catch (IOException e)
        {
            Log.e("Exception", "File write failed: " + e.toString());
        }

        String maxScore = new String(bytes);
        return Integer.parseInt(maxScore);
    }
}