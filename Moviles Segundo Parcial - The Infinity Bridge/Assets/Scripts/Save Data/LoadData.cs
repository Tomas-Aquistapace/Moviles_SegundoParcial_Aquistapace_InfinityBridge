﻿using UnityEngine;

public class LoadData : MonoBehaviour
{
    [SerializeField] private static PlayerData data;

    private void Awake()
    {
        data = SaveSystem.LoadPlayer();
    }

    public static int GetActualRecord()
    {
        return data.points;
    }
    
    public static int GetActualCoins()
    {
        return data.coins;
    }
    
    public static int GetActualSkin()
    {
        return data.skin;
    }
    
    public static bool GetSkinState(int skin)
    {
        if (skin == 1)
            return data.froggy;
        else if (skin == 2)
            return data.skelly;
        else
            return true;
    }

    // ===================

    public static void SetActualCoins(int value)
    {
        data.coins -= value;
    }
    
    public static void SetActualSkin(int value)
    {
        data.skin = value;
    }
    
    public static void SetFroggeyState(bool value)
    {
        data.froggy = value;
    }
    
    public static void SetSkellyState(bool value)
    {
        data.skelly = value;
    }

    // ===================

    public static void SaveData()
    {
        //PlayerState player = new PlayerState();
        //
        //player.points = GetActualRecord();
        //player.coins = GetActualCoins();
        //player.skin = GetActualSkin();
        //player.froggy = data.froggy;
        //player.skelly = data.skelly;

        SaveSystem.SaveData(data);
    }
}
