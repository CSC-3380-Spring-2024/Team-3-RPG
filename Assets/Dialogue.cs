using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox; // Reference to the GameObject containing the dialogue box UI elements
    public TextMeshProUGUI textComponent;
    public IntroductionPrompt IntroductionPrompt;
    public GiveQuestPrompt GiveQuestPrompt;
    public float textSpeed = 0.05f; // Default text speed value

    private string[] introductionLines;
    private string[] giveQuestLines;
    private bool introCompleted = false; // Indicates if the intro dialogue is completed
    private bool waitingForSpace = false; // Indicates if the script is waiting for space bar input

    void Start()
    {
        introductionLines = IntroductionPrompt.lines;
        giveQuestLines = GiveQuestPrompt.lines;

        StartCoroutine(ShowIntroduction());
    }

    void Update()
    {
        if (waitingForSpace && Input.GetKeyDown(KeyCode.Space))
        {
            // If waiting for space and space bar is pressed, proceed to the next line
            waitingForSpace = false;
            NextLine();
        }

        // Check for "E" key to proceed to the give quest prompt
        if (Input.GetKeyDown(KeyCode.E) && introCompleted)
        {
            // If intro is completed and "E" is pressed, proceed to the give quest prompt
            StartCoroutine(ShowGiveQuest());
        }
    }

    IEnumerator ShowIntroduction()
    {
        dialogueBox.SetActive(true); // Activate the dialogue box

        // Display the introduction lines
        for (int i = 0; i < introductionLines.Length; i++)
        {
            textComponent.text = string.Empty;

            // Display the current line character by character
            foreach (char c in introductionLines[i].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed); // Use textSpeed variable
            }

            // Wait for a short delay after displaying each line
            //yield return new WaitForSeconds(1f);

            // Set waiting for space to true after displaying the line
            waitingForSpace = true;

            // Wait until space bar is pressed to proceed to the next line
            while (waitingForSpace)
            {
                yield return null;
            }
        }

        // Hide the dialogue box when the introduction lines are finished
        //dialogueBox.SetActive(false);
        introCompleted = true;
    }

    IEnumerator ShowGiveQuest()
    {
        dialogueBox.SetActive(true); // Activate the dialogue box

        // Display the give quest lines
        for (int i = 0; i < giveQuestLines.Length; i++)
        {
            textComponent.text = string.Empty;

            // Display the current line character by character
            foreach (char c in giveQuestLines[i].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed); // Use textSpeed variable
            }

            // Wait for a short delay after displaying each line
            //yield return new WaitForSeconds(1f);
            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        // Hide the dialogue box when the give quest lines are finished
        dialogueBox.SetActive(false);
    }

    void NextLine()
    {
        if (introCompleted)
        {
            StartCoroutine(ShowGiveQuest());
        }
    }
}
