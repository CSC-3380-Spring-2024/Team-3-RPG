using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this makes quests scriptable objects
[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest/New Quest", order = 1)]
public class Quest : ScriptableObject
{
    // quest name
    public string questName;

    // quest description
    public string description;

    // quest dialogue
    public string[] dialogue;

    // kill count
    public int killCount = 0;

    // constructor for this quest
    public void Initialize(string name, string description, string[] dialogue)
    {
        this.questName = name;
        this.description = description;
        this.dialogue = dialogue;
    }
}