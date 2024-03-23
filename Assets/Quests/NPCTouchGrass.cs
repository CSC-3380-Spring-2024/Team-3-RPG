using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCTouchGrass : MonoBehaviour
{
    public TextMeshProUGUI questTextUI;
    public string questName = "Touch Grass!";
    public string questDescription = "Go to the grassy area.";
    private bool isPlayerInRange = false;

    private QuestManager questManager;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        questTextUI.text = "";
    }

    private void Update()
    {
        // Check for interaction (e.g., if the player presses the 'E' key while in range)
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ActivateQuest();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            // Optional: Display a prompt to the player indicating they can interact
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // Optional: Hide the interaction prompt
        }
    }

    private void ActivateQuest()
    {
        if (questManager != null)
        {
            questManager.AddQuest(questName, questDescription);
            questTextUI.text = "New Quest: Touch Grass!";
            StartCoroutine(HideQuestTextAfterDelay(5)); // Hide after 5 seconds
            //Debug.Log("Quest Activated: " + questName);
            // Optionally, disable further interactions if the quest should only be given once
            this.enabled = false;
        }
    }

    IEnumerator HideQuestTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        questTextUI.text = "";
    }

}
