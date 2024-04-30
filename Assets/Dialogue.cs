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
    public TouchGrass TouchGrass;
    public float textSpeed = 0.05f; // Default text speed value
    private string[] introductionLines;
    private string[] giveQuestLines;
    private string[] sisterCindylines;
    private string[] touchGrasslines;
    private bool introCompleted = false; // Indicates if the intro dialogue is completed
    private bool giveQuestCompleted = false;
    private bool sisterCindyCompleted = false;
    private bool waitingForSpace = false; // Indicates if the script is waiting for space bar input
    private bool instantFinish = false;
    private QuestManager questManager;
    public Quest questToCheck;

    void Start()
    {
        introductionLines = IntroductionPrompt.lines;
        giveQuestLines = GiveQuestPrompt.lines;
        sisterCindylines = SisterCindy.lines;
        touchGrasslines = TouchGrass.lines;

        StartCoroutine(ShowDialogue(introductionLines));
    }
    private void Awake()
    {
        questManager = QuestManager.Instance;
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
        if (questManager.IsQuestActive(questToCheck) && Input.GetKeyDown(KeyCode.E) && introCompleted && giveQuestCompleted && sisterCindyCompleted)
        {
            // If intro is completed and "E" is pressed, proceed to the give quest prompt
            StartCoroutine(ShowDialogue(touchGrasslines));
        }

        else if (Input.GetKeyDown(KeyCode.E) && introCompleted && giveQuestCompleted)
        {
            // If intro is completed and "E" is pressed, proceed to the give quest prompt
            StartCoroutine(ShowDialogue(sisterCindylines));
        }

        // Check for "E" key to proceed to the give quest prompt
        else if (Input.GetKeyDown(KeyCode.E) && introCompleted)
        {
            // If intro is completed and "E" is pressed, proceed to the give quest prompt
            StartCoroutine(ShowDialogue(giveQuestLines));
        }

    }
    IEnumerator ShowDialogue(string[] lines)
    {
        dialogueBox.SetActive(true); // Activate the dialogue box

        for (int i = 0; i < lines.Length; i++)
        {
            textComponent.text = string.Empty;
            instantFinish = false;

            // Display the current line character by character
            foreach (char c in lines[i].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed); // Use textSpeed variable
                if (instantFinish == true)
                {
                    break;
                }
            }
            textComponent.text = lines[i];

            // Set waiting for space to true after displaying the line
            waitingForSpace = true;

            // Wait until space bar is pressed to proceed to the next line
            while (waitingForSpace)
            {
                yield return null;
            }
        }

        if (lines == introductionLines)
        {
            introCompleted = true;

        }
        else if (lines == giveQuestLines)
        {
            giveQuestCompleted = true;
        }
        else if (lines == sisterCindylines)
        {
            sisterCindyCompleted = true;
            //dialogueBox.SetActive(false);
        }
    }
}
