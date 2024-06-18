using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerData player;

    // Start is called before the first frame update
    void Start()
    {
        player = new PlayerData();
        
        Debug.Log("hello world!");
        player.SavePlayer();
        player.Username = "dummy";
        Debug.Log(player.Username);
        player.LoadPlayer();
        Debug.Log(player.Username);

        Debug.Log($"Stat Count: {player.GameData.Stats.Count}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
