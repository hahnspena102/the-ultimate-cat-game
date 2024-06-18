using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;



[System.Serializable]
public class PlayerData
{

    [SerializeField] private string username;
    [SerializeField] private int highScore;
    [SerializeField] private int deathCount;
    [SerializeField] private GameData gameData;

    public global::System.String Username { get => username; set => username = value; }
    public global::System.Int32 HighScore { get => highScore; set => highScore = value; }
    public global::System.Int32 DeathCount { get => deathCount; set => deathCount = value; }
    public GameData GameData { get => gameData; set => gameData = value; }

    public PlayerData()
    {
       username = "user";
       highScore = 123;
       deathCount = 0;
       gameData = new GameData();

       Debug.Log(gameData.Stats.Count);
    }

    public void ResetPlayer()
    {
        username = "user";
        highScore = 123;
        deathCount = 0;
        gameData = new GameData();
    }

    
    public void SetPlayer(PlayerData newPlayer) {
        username = newPlayer.username;
        highScore = newPlayer.highScore;
        deathCount = newPlayer.deathCount;
    }

    public void SavePlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.cat";

        using (Stream stream = File.Open(path, FileMode.Create))
        {
            try 
            {
                formatter.Serialize(stream, this);
                Debug.Log("Successfully serialized.");
            }
            catch (SerializationException e) 
            {
                Debug.LogError("Failed to serialize. Reason: " + e.Message);
                throw;
            }
        }
    }

    public void LoadPlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.cat";

        if (!File.Exists(path))
        {
            Debug.LogError("Save file not found in" + path);
        }

        using (Stream stream = File.Open(path, FileMode.Open))
        {
            try 
            {
                PlayerData newPlayer = formatter.Deserialize(stream) as PlayerData;
                SetPlayer(newPlayer);
            }
            catch (SerializationException e)
            {
                Debug.LogError("Failed to deserialize. Reason: " + e.Message);
                throw;
            }   
        }
    }
}
    