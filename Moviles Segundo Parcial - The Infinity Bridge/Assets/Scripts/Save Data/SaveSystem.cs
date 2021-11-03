using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Path.GetDataPath();
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData();

        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static void SaveData(PlayerState player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Path.GetDataPath();
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static void SaveData(PlayerData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Path.GetDataPath();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Path.GetDataPath();

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogWarning("Save File not found in " + path + ". Creating a new one");

            //PlayerData player = new PlayerData();
            //PlayerState player = null;
            SaveData();

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
    }
}



public static class Path
{
    public static string GetDataPath()
    {
        return Application.persistentDataPath + "/player.data";
    }
}
