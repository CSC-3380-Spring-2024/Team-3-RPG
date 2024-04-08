using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox; // Reference to the GameObject containing the dialogue box UI elements
    public Button yourButton; // Reference to your intro button
    public Button giveQuestButton; // Reference to your give quest button
    public TextMeshProUGUI textComponent;
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
            yourButton.onClick.AddListener(() => StartDialogue(introductionLines));
            Debug.Log("start button is clicked");
        }

    }

    void Update()
    {
        if (giveQuestButton != null)
        {
            giveQuestButton.onClick.AddListener(() => StartDialogue(giveQuestLines));
            Debug.Log("quest button is clicked");
        }
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

    public void StartDialogue(string[] linesArray)
    {
        dialogueBox.SetActive(true); // Activate the dialogue box

        // Start with the introduction prompt
        currentLineIndex = 0;
        typingCoroutine = StartCoroutine(TypeLine(linesArray));
    }

    void NextLine(string[] linesArray)
    {

        // Check if there are more lines in the current prompt
        if (currentLineIndex < linesArray.Length - 1)
        {
            // Move to the next line
            currentLineIndex++;
            typingCoroutine = StartCoroutine(TypeLine(giveQuestLines));
        }
        else
        {

            // Hide the dialogue box when all lines are finished
            dialogueBox.SetActive(false);

        }
    }

    IEnumerator TypeLine(string[] linesArray)
    {
        textComponent.text = string.Empty;

        // Display each line of the prompt one by one
        for (int i = 0; i < linesArray.Length; i++)
        {
            // Display the current line character by character
            foreach (char c in linesArray[i].ToCharArray())
            {
                textComponent.text += c;
                yield return null; // Wait for one frame
            }

            // Wait for a short delay after displaying each line
            yield return new WaitForSeconds(1f);
            textComponent.text = string.Empty;
            //if i want to change between making it an enter or space do it here
        }
        //dialogueBox.SetActive(false);

        // After displaying all lines, move to the next prompt
        //NextLine(giveQuestLines); this will make it go onto the give questlines
    }
}
