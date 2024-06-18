using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private string name;
    [SerializeField] private int value;
    [SerializeField] private int valueMax;
    [SerializeField] private bool unlocked;

    public string Name { get => name; set => name = value; }
    public int Value { get => value; set => this.value = value; }
    public int ValueMax { get => valueMax; set => valueMax = value; }
    public global::System.Boolean Unlocked { get => unlocked; set => unlocked = value; }

    public Stat(string name, int valueMax)
    {
        this.name = name;
        this.value = valueMax;
        this.valueMax = valueMax;
        this.unlocked = false;
    }

    public Stat(string name, int value, int valueMax, bool unlocked)
    {
        this.name = name;
        this.value = value;
        this.valueMax = valueMax;
        this.unlocked = unlocked;
    }

}