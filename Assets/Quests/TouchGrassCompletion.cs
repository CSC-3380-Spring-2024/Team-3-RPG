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
            questManager.DeactivateQuest(questToComplete);
            Dialogue.Instance.TriggerDialogue(TouchGrass.finishGrass);
            Debug.Log($"Quest '{questToComplete.questName}' has been completed.");
            this.enabled = false;
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