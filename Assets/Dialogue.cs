using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox; // Reference to the GameObject containing the dialogue box UI elements
    public TextMeshProUGUI textComponent;
    public IntroductionPrompt IntroductionPrompt;
    public Viking viking;
    public SisterCindy SisterCindy;
    public TouchGrass TouchGrass;
    public GoblinQuest goblin;
    public float textSpeed = 0.05f; // Default text speed value
    private string[] introductionLines;
    public string[] sisterCindylines;
    public string[] touchGrasslines;
    public string[] vikingLines;
    public string[] goblinLines;
    private bool introCompleted = false; // Indicates if the intro dialogue is completed
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
    private bool dialogueRunning;
    public static Dialogue Instance { get; private set; }
    private PlayerController playerController;

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
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        introductionLines = IntroductionPrompt.lines;
        sisterCindylines = SisterCindy.lines;
        touchGrasslines = TouchGrass.lines;
        vikingLines = Viking.lines;
        goblinLines = GoblinQuest.lines;
        playerController.canMove = false;
        StartCoroutine(ShowDialogue(introductionLines));
        if (introCompleted)
        {
            playerController.canMove = true;
        }

    }


    void Update()
    {
        HandleInput();

        if (questManager.IsQuestActive(questToCheck) && Input.GetKeyDown(KeyCode.Q) && touchGrassGiven == false)
        {
            touchGrassGiven = true;
        }
        else if (questManager.IsQuestActive(sisterCindyQuest) && Input.GetKeyDown(KeyCode.Q))
        {
            //dialogueBox.SetActive(true);
            // If intro is completed and "E" is pressed, proceed to the give quest prompt
            //StartCoroutine(ShowDialogue(sisterCindylines));
        }
    }

    public IEnumerator ShowDialogue(string[] lines)
    {
        dialogueRunning = true;
        dialogueBox.SetActive(true); // Activate the dialogue box


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
                    break; // Exit the character loop
                }
                yield return new WaitForSeconds(textSpeed); // Wait before showing the next character
            }
            textComponent.text = line; // Display the full line immediately
            yield return new WaitForSeconds(.2f);

            instantFinish = false; // Reset the instant finish flag
            waitingForSpace = true; // Wait for the player to press space to continue

            // Wait until the space bar is pressed to proceed to the next line
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        dialogueRunning = false;
        dialogueBox.SetActive(false);
        playerController.canMove = true;


        if (lines == introductionLines) { introCompleted = true; }
    }

    public void TriggerDialogue(string[] lines)
    {
        dialogueBox.SetActive(true);
        if (dialogueRunning == false)
        {
            playerController.canMove = false;
            StartCoroutine(ShowDialogue(lines));
        }
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
