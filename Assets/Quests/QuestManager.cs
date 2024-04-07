using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // List of quests
    public List<Quest> quests = new List<Quest>();


    void Update()
    {
        // Add quests to the list here
        //AddQuest("Touch Grass!", "Go to the grassy area.");
    }

    public void AddQuest(string name, string description)
    {
        Quest newQuest = new Quest(name, description);
        quests.Add(newQuest);
    }

    // Method to complete a quest
    public void CompleteQuest(string title)
    {
        Quest quest = quests.Find(q => q.questName == title);
        if (quest != null)
        {
            Debug.Log("YOU HAVE COMPLETED THE QUEST: " + quest.questName);
            quest.CompleteQuest();
            quests.Remove(quest);
        }
        else
        {
            Debug.Log("Quest not found.");
        }
    }
}