using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox; // Reference to the GameObject containing the dialogue box UI elements
    public Button yourButton; // Reference to your UI button
    public TextMeshProUGUI textComponent;
    private bool isIntroductionPrompt = true; // Indicates whether it's an introduction prompt
    private int currentLineIndex; // Index of the current line within the prompt
    private Coroutine typingCoroutine; // Reference to the typing coroutine

    public IntroductionPrompt IntroductionPrompt;
    public GiveQuestPrompt GiveQuestPrompt;
    string[] introductionLines = IntroductionPrompt.lines;

    // Accessing the lines array of the give quest prompt
    string[] giveQuestLines = GiveQuestPrompt.lines;

    void Start()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
            // we dont need the dialogue box until 
        }

        if (yourButton != null)
        {
            yourButton.onClick.AddListener(StartDialogue);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if there's an ongoing typing coroutine
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }

            // Proceed to the next line or prompt
            NextLine(introductionLines);
        }
    }

    public void StartDialogue()
    {
        dialogueBox.SetActive(true); // Activate the dialogue box

        // Start with the introduction prompt
        isIntroductionPrompt = true;
        currentLineIndex = 0;
        typingCoroutine = StartCoroutine(TypeLine(introductionLines));
    }

    void NextLine(string[] linesArray)
    {


        // Check if there are more lines in the current prompt
        if (currentLineIndex < linesArray.Length - 1)
        {
            // Move to the next line
            currentLineIndex++;
            typingCoroutine = StartCoroutine(TypeLine(introductionLines));
        }
        else
        {
            // If it's the last line of the introduction prompt, switch to the quest prompt
            if (isIntroductionPrompt)
            {
                isIntroductionPrompt = false;
                currentLineIndex = 0;
                typingCoroutine = StartCoroutine(TypeLine(giveQuestLines));
            }
            else
            {
                // Hide the dialogue box when all lines are finished
                dialogueBox.SetActive(false);
            }
        }
    }

    IEnumerator TypeLine(string[] linesArray)
    {
        textComponent.text = string.Empty;

        // Determine which prompt to use based on the context

        // Display the current line character by character
        foreach (char c in linesArray[currentLineIndex].ToCharArray())
        {
            textComponent.text += c;
            yield return null; // Wait for one frame
        }
    }
}
