using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerData player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello world!");
        player.SavePlayer();
        player.Username = "dummy";
        player.LoadPlayer();
        Debug.Log(player.Username);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
