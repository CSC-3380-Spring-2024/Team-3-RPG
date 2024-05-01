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
    public SisterCindy SisterCindy;
    public TouchGrass TouchGrass;
    public float textSpeed = 0.05f; // Default text speed value
    private string[] introductionLines;
    //private string[] giveQuestLines;
    public string[] sisterCindylines;
    public string[] touchGrasslines;
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


    void Start()
    {
        introductionLines = IntroductionPrompt.lines;
        // giveQuestLines = GiveQuestPrompt.lines;
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
        }
        if (instantFinish == false && Input.GetKeyDown(KeyCode.Space))
        {
            instantFinish = true;
        }

        Debug.Log("Dialogue box is active: " + dialogueBox.activeSelf);
        if (questManager.IsQuestActive(questToCheck) && Input.GetKeyDown(KeyCode.Q) && touchGrassGiven == false)
        {
            // If intro is completed and "E" is pressed, proceed to the give quest prompt
            Debug.Log("setting dialogue box to true-touch grass");
            Debug.Log("Dialogue box is active: " + dialogueBox.activeSelf);
            dialogueBox.SetActive(true);
            ShowBox();
            StartCoroutine(ShowDialogue(touchGrasslines));
            touchGrassGiven = true;
        }
        else if (questManager.IsQuestActive(sisterCindyQuest) && Input.GetKeyDown(KeyCode.Q))
        {
            dialogueBox.SetActive(true);
            // If intro is completed and "E" is pressed, proceed to the give quest prompt
            StartCoroutine(ShowDialogue(sisterCindylines));
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
        Debug.Log("Dialogue box is active: " + dialogueBox.activeSelf);
        //dialogueBox.SetActive(true);
        Debug.Log("Dialogue box is active: " + dialogueBox.activeSelf);
    }
    public void ShowBox()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true); // Turn on the dialogue box
            Debug.Log("Dialogue box is active: " + dialogueBox.activeSelf);
        }
    }
}
