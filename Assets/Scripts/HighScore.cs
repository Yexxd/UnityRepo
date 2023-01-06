using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HighScore : MonoBehaviour
{
    public static string playerNameHigh = "N/A";
    public static int highScore = 0;    

    public static void SaveFile(string playerName, int score)
    {
        string destination = Application.persistentDataPath + "/save.dat";

        FileStream file;

        if(File.Exists(destination)) 
            file = File.OpenWrite(destination);
        else 
            file = File.Create(destination);

        GameData data = new GameData(playerName, score);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public static void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if(File.Exists(destination)) 
            file = File.OpenRead(destination);
        else
        {
            Debug.Log("File not found");
            return;
        }

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            GameData data = (GameData) bf.Deserialize(file);
            playerNameHigh = data.playerName;
            highScore = data.score;
        }
        catch (System.Exception e)
        {
            Debug.Log(e.ToString());
        }
        finally
        {
            file.Close();
        }
    }
}

 [System.Serializable]
public class GameData
{
    public string playerName;
    public int score;
    public GameData(string name, int newScore)
    {
        playerName = name;
        score = newScore;
    }
}
