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

    public global::System.String Username { get => username; set => username = value; }
    public global::System.Int32 HighScore { get => highScore; set => highScore = value; }
    public global::System.Int32 DeathCount { get => deathCount; set => deathCount = value; }

    public PlayerData()
    {
       username = "user";
       highScore = 123;
       deathCount = 0;
    }
/*
    public void ResetGame()
    {
        // Current Game Stats
        this.catName = DataManager.catNameInput;
        this.breed = "Breed";
        this.points = 0;
        this.difficulty = 1;
        this.coins = 0;

        this.stats = new List<Stats>()
        {
            new Stats ("Love", 750),
            new Stats ("Hunger", 1000),
            new Stats ("Thirst", 600),
            new Stats ("Energy", 1600),
            new Stats ("Clean", 2000),
            new Stats ("Cozy", 100000)
        };

        // Upgrades
        this.upgrades = new List<List<bool>>()
        {
            new List<bool>() {false, false, false, false, false, false, false, false, false},
            new List<bool>() {false, false, false, false, false, false, false, false, false},
            new List<bool>() {false, false, false, false, false, false, false, false, false},
            new List<bool>() {false, false, false, false, false, false, false, false, false},
            new List<bool>() {false, false, false, false, false, false, false, false, false},
            new List<bool>() {false, false, false, false, false, false, false, false, false},
            new List<bool>() {false, false, false, false, false, false, false, false, false},
            new List<bool>() {false, false, false, false, false, false, false, false, false},
            new List<bool>() {false, false, false, false, false, false, false, false, false},
        };

        // Items
        this.items = new List<string> { "Empty", "Empty", "Empty" };

        // Hunger
        this.satiation = 0;
        this.satiationMax = 100;

        // Energy
        this.isDreaming = true;
        this.dreamRespawn = 0;
    }
    */

    public void ResetPlayer()
    {
        username = "user";
        highScore = 123;
        deathCount = 0;
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

    //SerializablePlayerData data = new SerializablePlayerData(this);
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


/*
    public void LoadSerializablethis(SerializablePlayerData serial)
    {
        // All Time Stats
        highScore = serial.highScore;
        this.deathCount = serial.deathCount;

        // Current Game Stats 
        this.catName = serial.catName;
        this.breed = serial.breed;
        this.points = serial.points;
        this.difficulty = serial.difficulty;
        this.coins = serial.coins;

        for (int i = 0; i < serial.statValue.Count; i++)
        {
            this.stats[i].Value = serial.statValue[i];
            this.stats[i].ValueMax = serial.statValueMax[i];
        }

        for (int i = 0; i < serial.upgrades.Count; i++)
        {
            int upgradeIndex1 = (int)System.Math.Floor(i / 9f);
            int upgradeIndex2 = (int)System.Math.Floor(i % 9f);
            this.upgrades[upgradeIndex1][upgradeIndex2] = serial.upgrades[i];
        }

        for (int i = 0; i < serial.items.Count; i++)
        {
            this.items[i] = serial.items[i];
        }

        this.satiation = serial.satiation;
        this.satiation = serial.satiation;

        this.isDreaming = serial.isDreaming;
        this.dreamRespawn = serial.dreamRespawn;
    }
  */
}
    