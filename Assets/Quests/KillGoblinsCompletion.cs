using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoblinsCompletion : MonoBehaviour
{
    // QuestManager reference
    private QuestManager questManager;

    // name of the quest to complete
    public Quest questToComplete;

    // name of prerequisite quest that should be completed before
    public Quest prerequisiteQuest;

    // flag to determine if the player is in range
    public bool isPlayerInRange = false;

    // function to ensure the QuestManager is initialized
    private void Awake()
    {
        questManager = QuestManager.Instance;
    }

    private void Update()
    {
        if (questToComplete.killCount == 5)
        {
            if (questManager.IsQuestComplete(prerequisiteQuest))
            {
                questManager.CompleteQuest(questToComplete);
                questManager.DeactivateQuest(questToComplete);
                Dialogue.Instance.TriggerDialogue(GoblinQuest.finishGob);
                Debug.Log("ALL GOBLINS DEFEATED");
                this.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (questManager.IsQuestActive(questToComplete))
        {
            QuestEvents.TriggerGoblinDeath(null);
            Debug.Log("Killed a goblin!");
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
