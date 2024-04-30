using UnityEngine;

public class QuestGiverJLD : MonoBehaviour
{
    // flag to determine if the player is in range
    public bool isPlayerInRange = false;

    // quests that JLD will give us
    public Quest quest1;
    public Quest quest2;
    public Quest quest3;
    public Quest quest4;

    // QuestManager reference
    private QuestManager questManager;

    private void Awake()
    {
        questManager = QuestManager.Instance;
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (questManager != null && !questManager.IsQuestComplete(questManager.startingQuest))
            {
                questManager.CompleteQuest(questManager.startingQuest);
                questManager.DeactivateQuest(questManager.startingQuest);
                Debug.Log($"Quest '{questManager.startingQuest}' has been completed!");
            }

            else if(questManager.IsQuestComplete(questManager.startingQuest))
            {
                // gives first quest
                if (questManager.IsQuestComplete(questManager.startingQuest) && !questManager.quests.Contains(quest1))
                {
                    questManager.AddQuest(quest1);
                    questManager.ActivateQuest(quest1);
                    Debug.Log($"Quest '{quest1}' has been accepted!");
                }

                // check if quest 1 is complete
                // gives next quest if true
                if (questManager.IsQuestComplete(quest1) && !questManager.quests.Contains(quest2))
                {
                    questManager.AddQuest(quest2);
                    questManager.ActivateQuest(quest2);
                    Debug.Log($"Quest '{quest2}' has been accepted!");
                }

                // check if quest 2 is complete
                // gives next quest if true
                if (questManager.IsQuestComplete(quest2) && !questManager.quests.Contains(quest3))
                {
                    questManager.AddQuest(quest3);
                    questManager.ActivateQuest(quest3);
                    Debug.Log($"Quest '{quest3}' has been accepted!");
                }

                // check if quest 3 is complete
                // gives next quest if true
                if (questManager.IsQuestComplete(quest3) && !questManager.quests.Contains(quest4))
                {
                    questManager.AddQuest(quest4);
                    questManager.ActivateQuest(quest4);
                    Debug.Log($"Quest '{quest4}' has been accepted!");
                    this.enabled = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}