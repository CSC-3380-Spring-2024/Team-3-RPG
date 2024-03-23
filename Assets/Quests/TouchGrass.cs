using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Make sure to include this for TextMeshPro

public class TouchGrass : MonoBehaviour
{
    private QuestManager questManager;
    public TextMeshProUGUI questCompletionTextUI;

    private void Start()
    {
        // Find the QuestManager instance in the scene and store a reference to it
        questManager = FindObjectOfType<QuestManager>();
        if (questManager == null)
        {
            Debug.LogError("QuestManager not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            questManager.CompleteQuest("Touch Grass!");
            ShowCompletionMessage();
        }
    }

    private void ShowCompletionMessage()
    {
        questCompletionTextUI.text = "You Touched Grass! Congratulations!";
        StartCoroutine(HideQuestTextAfterDelay(5)); // Hide after 5 seconds
    }

    IEnumerator HideQuestTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        questCompletionTextUI.text = "";
    }
}