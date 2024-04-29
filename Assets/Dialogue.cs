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
    public SisterCindy SisterCindy;
    public float textSpeed = 0.05f; // Default text speed value
    private string[] introductionLines;
    private string[] giveQuestLines;
    private string[] sisterCindylines;
    private bool introCompleted = false; // Indicates if the intro dialogue is completed
    private bool giveQuestCompleted = false;
    private bool sisterCindyCompleted = false;
    private bool waitingForSpace = false; // Indicates if the script is waiting for space bar input
    private bool instantFinish = false;

    void Start()
    {
        introductionLines = IntroductionPrompt.lines;
        giveQuestLines = GiveQuestPrompt.lines;
        sisterCindylines = SisterCindy.lines;

        StartCoroutine(ShowIntroduction());
    }

    void Update()
    {
        if (waitingForSpace && Input.GetKeyDown(KeyCode.Space))
        {
            // If waiting for space and space bar is pressed, proceed to the next line
            waitingForSpace = false;
            //NextLine();
        }
        if (instantFinish == false && Input.GetKeyDown(KeyCode.Space))
        {
            instantFinish = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && introCompleted && giveQuestCompleted)
        {
            // If intro is completed and "E" is pressed, proceed to the give quest prompt
            StartCoroutine(ShowSisterCindy());
        }

        // Check for "E" key to proceed to the give quest prompt
        else if (Input.GetKeyDown(KeyCode.E) && introCompleted)
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
            instantFinish = false;

            // Display the current line character by character
            foreach (char c in introductionLines[i].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed); // Use textSpeed variable
                if (instantFinish == true)
                {
                    break;
                }
            }
            textComponent.text = introductionLines[i];


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
            instantFinish = false;

            // Display the current line character by character
            foreach (char c in giveQuestLines[i].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed); // Use textSpeed variable
                if (instantFinish == true)
                {
                    break;
                }
            }
            textComponent.text = giveQuestLines[i];

            // Wait for a short delay after displaying each line
            //yield return new WaitForSeconds(1f);
            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
        }

        // Hide the dialogue box when the give quest lines are finished
        //dialogueBox.SetActive(false);
        giveQuestCompleted = true;
    }

    IEnumerator ShowSisterCindy()
    {
        dialogueBox.SetActive(true); // Activate the dialogue box

        // Display the introduction lines
        for (int i = 0; i < sisterCindylines.Length; i++)
        {
            textComponent.text = string.Empty;
            instantFinish = false;

            // Display the current line character by character
            foreach (char c in sisterCindylines[i].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed); // Use textSpeed variable
                if (instantFinish == true)
                {
                    break;
                }
            }
            Debug.Log(sisterCindylines[i]);
            textComponent.text = sisterCindylines[i];


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
        sisterCindyCompleted = true;
        dialogueBox.SetActive(false);

    }

    // void NextLine()
    // {
    //     if (introCompleted && giveQuestCompleted)
    //     {
    //         StartCoroutine(ShowSisterCindy());
    //     }
    //     else if (introCompleted)
    //     {
    //         StartCoroutine(ShowGiveQuest());
    //     }

    // }
}
