using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this makes quests scriptable objects
[CreateAssetMenu(fileName = "New Quest SO", menuName = "ScriptableObjects/New Quest", order = 1)]
public class Quest : ScriptableObject
{
    // quest name
    public string questName;

    // kill count
    public int killCount = 0;

    // is the quest active
    public bool isActive = false;

    // constructor for this quest
    public void Initialize(string name)
    {
        this.questName = name;
    }
}