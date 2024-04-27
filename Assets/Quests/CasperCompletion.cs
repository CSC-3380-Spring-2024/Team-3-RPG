using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasperCompletion : MonoBehaviour
{
    // QuestManager reference
    private QuestManager questManager;

    // name of the quest to complete
    public string questToComplete;

    // flag to determine if the player is in range
    public bool isPlayerInRange = false;

    // function to ensure the QuestManager is initialized
    private void Awake()
    {
        questManager = QuestManager.Instance;
    }

    // function to constantly check if the player is in range and has pressed E
    // if true, completes this specific quest
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (questManager != null)
            {
                questManager.CompleteQuest(questToComplete);
                Debug.Log($"Quest '{questToComplete}' has been completed");
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