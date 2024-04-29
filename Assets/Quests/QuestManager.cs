using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // instance of QuestManager
    public static QuestManager Instance{get; private set;}

    // list of quests
    public List<Quest> quests = new List<Quest>();

    // Dictionary to track the completion status of each quest
    private Dictionary<Quest, bool> questCompletionStatus = new Dictionary<Quest, bool>();

    // starter quest
    public Quest startingQuest;
    public Quest goblinQuest;

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
        AddQuest(startingQuest);
    }

    public void Start()
    {
        goblinQuest.killCount = 0;
    }

    private void OnEnable()
    {
        // Subscribe to the Goblin death event when the Quest Manager is enabled
        QuestEvents.OnGoblinDied += OnGoblinDeath;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event when the Quest Manager is disabled
        QuestEvents.OnGoblinDied -= OnGoblinDeath;
    }

    // Handler for Goblin death event
    private void OnGoblinDeath(Goblin goblin)
    {
        if (goblinQuest != null)
        {
            goblinQuest.killCount++; // Increment the quest's kill count
            Debug.Log("Quest updated due to Goblin death");
        }
    }

    // function to add quest to the quest list
    public void AddQuest(Quest questToAdd)
    {
        if (!quests.Contains(questToAdd))
        {
            quests.Add(questToAdd);
            questCompletionStatus[questToAdd] = false;
            Debug.Log($"Quest '{questToAdd.questName}' added to the list.");
        }
    }

    // function to complete a quest
    // it looks in the quest list to find a matching title
    // if it finds one, it completes the quest and the removes it from the list
    public void CompleteQuest(Quest questToComplete)
    {
        if (questToComplete == null)
        {
            return;
        }

        if (questCompletionStatus.ContainsKey(questToComplete))
        {
            questCompletionStatus[questToComplete] = true; // Mark as complete
        }
    }

    // function to check quest completion status
    public bool IsQuestComplete(Quest questToCheck)
    {
        if (questCompletionStatus.ContainsKey(questToCheck))
        {
            bool isComplete = questCompletionStatus[questToCheck]; // Get the completion status
            return isComplete; // Return the completion status
        }

        return false; // If quest isn't in the dictionary, return false
    }
}