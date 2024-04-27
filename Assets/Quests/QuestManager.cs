using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // instance of QuestManager
    public static QuestManager Instance{get; private set;}

    // list of quests
    public List<Quest> quests = new List<Quest>();

    // function to start at beginning of game to make sure there is only one instance
    // of this manager
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // ensures persistence across scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // destroys any duplicate instances
            Destroy(gameObject);
        }
    }

    // function to add quest to the quest list
    public void AddQuest(Quest questToAdd)
    {
        if (!quests.Contains(questToAdd))
        {
            quests.Add(questToAdd);
            Debug.Log($"Quest '{questToAdd.questName}' added to the list.");
        }
    }

    // function to complete a quest
    // it looks in the quest list to find a matching title
    // if it finds one, it completes the quest and the removes it from the list
    public void CompleteQuest(string title)
    {
        Quest quest = quests.Find(q => q.questName == title);
        if (quest != null)
        {
            quest.CompleteQuest();
            quests.Remove(quest);
            // Debug.Log($"Quest '{title}' completed and removed from the list.");
        }
        else
        {
            // Debug.LogError($"Quest '{title}' not found.");
        }
    }
}