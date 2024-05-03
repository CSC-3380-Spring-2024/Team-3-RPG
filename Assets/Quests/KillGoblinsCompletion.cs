using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private bool wasInCombatScene = false;

    // function to ensure the QuestManager is initialized
    private void Awake()
    {
        questManager = QuestManager.Instance;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "WorldScene" && wasInCombatScene)
        {
            questToComplete.killCount += 1;  // Increment the kill count
            wasInCombatScene = false; // Reset the flag
        }
        else if (scene.name == "CombatScene")
        {
            wasInCombatScene = true; // Set the flag when entering the combat scene
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe to avoid memory leaks
    }

    private void Update()
    {
        if(questToComplete.killCount >= 1)
        {
            if (questManager.IsQuestComplete(prerequisiteQuest))
            {
                questManager.CompleteQuest(questToComplete);
                questManager.DeactivateQuest(questToComplete);
                Dialogue.Instance.TriggerDialogue(GoblinQuest.finishGob);
                Debug.Log("GOBLIN DEFEATED");
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
