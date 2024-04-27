using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGrassCompletion : MonoBehaviour
{
    // QuestManager reference
    private QuestManager questManager;

    // name of the quest to complete
    public string questToComplete;

    // function to ensure the QuestManager is initialized
    private void Awake()
    {
        questManager = QuestManager.Instance;
    }

    // function to check if the player enters the zone
    // if true, completes this specific quest
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (questManager != null)
            {
                questManager.CompleteQuest(questToComplete);
                Debug.Log($"Quest '{questToComplete}' has been completed");
            }
        }
    }
}