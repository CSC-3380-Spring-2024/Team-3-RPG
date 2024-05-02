using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox; // Reference to the GameObject containing the dialogue box UI elements
    public TextMeshProUGUI textComponent; // this is how unity sees the text
    public IntroductionPrompt IntroductionPrompt; // getting the introduction prompt
    public GiveQuestPrompt GiveQuestPrompt;// getting the first quest prompt - jld
    public SisterCindy SisterCindy; // getting the sister cindy prompt
    public float textSpeed = 0.05f; // Default text speed value
    private string[] introductionLines; // getting the lines from intro
    private string[] giveQuestLines;// getting the lines from jld
    private string[] sisterCindylines;// getting the lines from sister cindy
    private bool introCompleted = false; //  if the intro dialogue is completed
    private bool giveQuestCompleted = false; // these are used to make sure the order is correct -- for questing
    private bool sisterCindyCompleted = false; // need to add mrore dialogue promots, not used now will be used later
    private bool waitingForSpace = false; //  if the script is waiting for space bar input
    private bool instantFinish = false; // if user puts spacebar before line is finished

    void Start()
    {
        introductionLines = IntroductionPrompt.lines; // intro
        giveQuestLines = GiveQuestPrompt.lines;//give quest
        sisterCindylines = SisterCindy.lines;//sister cindy
        StartCoroutine(ShowDialogue(introductionLines));//intro starts immediately - no more button click for it
    }


    void Update()
    {
        if (waitingForSpace && Input.GetKeyDown(KeyCode.Space)) // this is for going to the next line
        {
            waitingForSpace = false;
            //  waiting for space and space bar is pressed, proceed to the next line
        }
        if (instantFinish == false && Input.GetKeyDown(KeyCode.Space)) // this is if the space bar is clicked during the character by character display
        {
            instantFinish = true; // finish the line of text
        }

        if (Input.GetKeyDown(KeyCode.E) && introCompleted && giveQuestCompleted) // e is for the next prompts
        {
            //  intro is completed and "E" is pressed, proceed to the sister cindy  prompt
            StartCoroutine(ShowDialogue(sisterCindylines));
        }

        //  "E" key to proceed to the give quest prompt
        else if (Input.GetKeyDown(KeyCode.E) && introCompleted)
        {
            //  intro is completed and "E" is pressed, proceed to the give quest prompt
            StartCoroutine(ShowDialogue(giveQuestLines));
        }
    }

    public IEnumerator ShowDialogue(string[] lines)
    {
        dialogueBox.SetActive(true); // Activate the dialogue box to display text

        for (int i = 0; i < lines.Length; i++)//for all the lines in the prompt
        {
            textComponent.text = string.Empty; // make it clean
            instantFinish = false; // dont finish yet

            // display the current line character by character
            foreach (char c in lines[i].ToCharArray())// all characters
            {
                textComponent.text += c;//add/display character 
                yield return new WaitForSeconds(textSpeed); // Use textSpeed variable to let it display at a set rate
                if (instantFinish == true) // space is clicked
                {
                    break;//break out of the char loop

                }
                yield return new WaitForSeconds(textSpeed); // Wait before showing the next character
            }
            textComponent.text = lines[i];//set the textbox to have the whole line

            // set waiting for space to true after displaying the line
            waitingForSpace = true;

            // wait until space bar is pressed to proceed to the next line
            while (waitingForSpace)
            {
                yield return null;//do nothing if waiting for space
            }
            //if waiting for space is false, exits loop, and restarts with the next line in the dialogue

        }
        dialogueRunning = false;
        dialogueBox.SetActive(false);
        playerController.canMove = true;


        if (lines == introductionLines) // set the intro as done
        {
            introCompleted = true;//done

        }
        else if (lines == giveQuestLines)// set jld as done
        {
            giveQuestCompleted = true;//done
        }
        else if (lines == sisterCindylines)// set the sister cindy as done
        {
            sisterCindyCompleted = true;//done
            dialogueBox.SetActive(false);//hide the dialogue box

        }
    }
}
