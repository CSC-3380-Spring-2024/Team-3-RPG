using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkToGhost : MonoBehaviour
{
    private QuestManager questManager;
    public TextMeshProUGUI questCompletionTextUI;
    private bool isPlayerInRange = false;

    private void Start()
    {
        // Find the QuestManager instance in the scene and store a reference to it
        questManager = FindObjectOfType<QuestManager>();
        if (questManager == null)
        {
            Debug.LogError("QuestManager not found in the scene.");
        }
    }

    private void Update()
    {
        // Check for interaction (e.g., if the player presses the 'E' key while in range)
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            questManager.CompleteQuest("Talk to the Ghost Guy.");
            ShowCompletionMessage();
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

    private void ShowCompletionMessage()
    {
        questCompletionTextUI.text = "You talked to the Ghost Guy!";
        StartCoroutine(HideQuestTextAfterDelay(5)); // Hide after 5 seconds
    }

    IEnumerator HideQuestTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        questCompletionTextUI.text = "";
    }
}