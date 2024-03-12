using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    Fetch,
    Kill,
    Location
}

[System.Serializable]
public class Quest
{
    public string title;
    public string description;
    public QuestType questType;
    public bool isComplete = false;
    public Collider2D targetLocation; // For location quests

    // Define other quest attributes here, such as rewards.

    public Quest(string title, string description, QuestType questType, Collider2D targetLocation = null)
    {
        this.title = title;
        this.description = description;
        this.questType = questType;
        this.targetLocation = targetLocation;
    }

    // Call this method to complete the quest
    public void CompleteQuest()
    {
        Debug.Log("You completed the quest!");
        isComplete = true;
        // Handle rewards or quest completion logic here
    }
}
