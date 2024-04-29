using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGrassCompletion : MonoBehaviour
{
    // QuestManager reference
    private QuestManager questManager;

    // name of the quest to complete
    public Quest questToComplete;

    // flag to determine if the player is in range
    public bool isPlayerInRange = false;

    // function to ensure the QuestManager is initialized
    private void Awake()
    {
        questManager = QuestManager.Instance;
    }

    private void Update()
    {
        if (isPlayerInRange && questManager != null && questManager.quests.Contains(questToComplete))
        {
            questManager.CompleteQuest(questToComplete); // Complete the quest
            Debug.Log($"Quest '{questToComplete.questName}' has been completed.");
            this.enabled = false;
        }
    }
    // function to check if the player enters the zone
    // if true, completes this specific quest
    // public void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         if (questManager != null)
    //         {
    //             if(questManager.IsQuestComplete(questToComplete))
    //             {
    //                 return;
    //             }
    //             else
    //             {
    //                 questManager.CompleteQuest(questToComplete);
    //                 Debug.Log($"Quest '{questToComplete}' has been completed");
    //             }
    //         }
    //     }
    // }

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