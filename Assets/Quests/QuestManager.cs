using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();

    // Singleton pattern for easy access
    public static QuestManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to add a new quest
    public void AddQuest(string title, string description, QuestType questType, Collider2D location)
    {
        Quest newQuest = new Quest(title, description, questType, location);
        quests.Add(newQuest);
    }

    // Method to complete a quest
    public void CompleteQuest(string title)
    {
        Quest quest = quests.Find(q => q.title == title);
        if (quest != null)
        {
            quest.CompleteQuest();
        }
    }
}
