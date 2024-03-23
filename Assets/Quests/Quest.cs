using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public string questName;
    public string description;
    public bool isComplete = false;

    public Quest(string name, string description)
    {
        this.questName = name;
        this.description = description;
    }

    public void CompleteQuest()
    {
        isComplete = true;
    }
}