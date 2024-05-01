using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox; // Reference to the GameObject containing the dialogue box UI elements
    public TextMeshProUGUI textComponent;
    public IntroductionPrompt IntroductionPrompt;
    //public GiveQuestPrompt GiveQuestPrompt;
    public Viking viking;
    public SisterCindy SisterCindy;
    public TouchGrass TouchGrass;
    public GoblinQuest goblin;
    public float textSpeed = 0.05f; // Default text speed value
    private string[] introductionLines;
    //private string[] giveQuestLines;
    public string[] sisterCindylines;
    public string[] touchGrasslines;
    public string[] vikingLines;
    public string[] goblinLines;
    private bool introCompleted = false; // Indicates if the intro dialogue is completed
    //private bool giveQuestCompleted = false;
    private bool sisterCindyCompleted = false;
    public bool touchGrassGiven = false;
    private bool waitingForSpace = false; // Indicates if the script is waiting for space bar input
    private bool instantFinish = false;
    private QuestManager questManager;
    public Quest questToCheck;//touch grass
    public Quest sisterCindyQuest;
    public Quest vikingQuest;
    public Quest casperQuest;
    public Quest goblinQuest;
    public static Dialogue Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            questManager = QuestManager.Instance;
        }
    }

    void Start()
    {
        introductionLines = IntroductionPrompt.lines;
        // giveQuestLines = GiveQuestPrompt.lines;
        sisterCindylines = SisterCindy.lines;
        touchGrasslines = TouchGrass.lines;
        vikingLines = Viking.lines;
        goblinLines = GoblinQuest.lines;

        StartCoroutine(ShowDialogue(introductionLines));

    }


    void Update()
    {
        HandleInput();
        // if (waitingForSpace && Input.GetKeyDown(KeyCode.Space))
        // {
        //     // If waiting for space and space bar is pressed, proceed to the next line
        //     waitingForSpace = false;
        // }
        // if (instantFinish == false && Input.GetKeyDown(KeyCode.Space))
        // {
        //     instantFinish = true;
        // }

        //Debug.Log("Dialogue box is active: " + dialogueBox.activeSelf);
        if (questManager.IsQuestActive(questToCheck) && Input.GetKeyDown(KeyCode.Q) && touchGrassGiven == false)
        {
            // If intro is completed and "E" is pressed, proceed to the give quest prompt
            //Debug.Log("setting dialogue box to true-touch grass");
            // Debug.Log("Dialogue box is active: " + dialogueBox.activeSelf);
            //dialogueBox.SetActive(true);
            //ShowBox();
            //StartCoroutine(ShowDialogue(touchGrasslines));
            touchGrassGiven = true;
        }
        else if (questManager.IsQuestActive(sisterCindyQuest) && Input.GetKeyDown(KeyCode.Q))
        {
            //dialogueBox.SetActive(true);
            // If intro is completed and "E" is pressed, proceed to the give quest prompt
            //StartCoroutine(ShowDialogue(sisterCindylines));
        }
        // else if (questManager.IsQuestActive(vikingQuest) && Input.GetKeyDown(KeyCode.E))
        // {
        //     // If intro is completed and "E" is pressed, proceed to the give quest prompt
        //     StartCoroutine(ShowDialogue(sisterCindylines));
        // }
        // else if (questManager.IsQuestActive(casperQuest) && Input.GetKeyDown(KeyCode.E))
        // {
        //     // If intro is completed and "E" is pressed, proceed to the give quest prompt
        //     StartCoroutine(ShowDialogue(sisterCindylines));
        // }
    }

    public IEnumerator ShowDialogue(string[] lines)
    {
        dialogueBox.SetActive(true); // Activate the dialogue box
                                     //Debug.Log("Dialogue box is active: " + dialogueBox.activeSelf);


        // Display the current line character by character
        foreach (string line in lines)
        {
            textComponent.text = ""; // Clear the text component at the start of each line
            foreach (char c in line)
            {
                textComponent.text += c; // Add each character to the text component
                if (instantFinish)
                {
                    // If the player presses space to finish the line instantly
                    textComponent.text = line; // Display the full line immediately
                    break; // Exit the character loop
                }
                yield return new WaitForSeconds(textSpeed); // Wait before showing the next character
            }

            instantFinish = false; // Reset the instant finish flag
            waitingForSpace = true; // Wait for the player to press space to continue

            // Wait until the space bar is pressed to proceed to the next line
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        dialogueBox.SetActive(false);


        // if (lines == introductionLines)
        // {
        //     introCompleted = true;

        // }
        // // else if (lines == giveQuestLines)
        // // {
        // //     giveQuestCompleted = true;
        // // }
        // else if (lines == sisterCindylines)
        // {
        //     sisterCindyCompleted = true;
        //     //dialogueBox.SetActive(false);
        // }
        //dialogueBox.SetActive(false);
        //Debug.Log("Dialogue box is active: " + dialogueBox.activeSelf);
        //dialogueBox.SetActive(true);
        //Debug.Log("Dialogue box is active: " + dialogueBox.activeSelf);
    }
    public void ShowBox()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true); // Turn on the dialogue box
            //Debug.Log("Dialogue box is active: " + dialogueBox.activeSelf);
        }
    }
    public void TriggerDialogue(string[] lines)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(ShowDialogue(lines));
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (waitingForSpace)
            {
                // Proceed to the next line of dialogue if the space bar is pressed
                waitingForSpace = false;
            }
            else
            {
                // Allow instant finishing of the current line
                instantFinish = true;
            }
        }
    }
}
