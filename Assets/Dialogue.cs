// Dialogue.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public Button yourButton;
    public TextMeshProUGUI textComponent;
    private int index;

    public IntroductionPrompt introductionPrompt;
    public GiveQuestPrompt giveQuestPrompt;

    private bool isIntroductionPrompt;  // Flag to indicate whether the current prompt is an introduction prompt

    // Start is called before the first frame update
    void Start()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }

        if (yourButton != null)
        {
            yourButton.onClick.AddListener(StartDialogue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if there's an ongoing typing coroutine
            if (typingCoroutine != null)
            {
                // Stop the typing coroutine
                StopCoroutine(typingCoroutine);

                // Proceed to the next line or prompt
                NextLine();
            }
        }

        // Check if we're currently displaying the introduction prompt
        if (isIntroductionPrompt)
        {
            // Check if all lines in the introduction prompt have been displayed
            if (currentLineIndex >= prompts[currentPromptIndex].lines.Length)
            {
                // All lines in the introduction prompt have been displayed, switch to give quest prompt
                SwitchToGiveQuestPrompt();
            }
        }
    }


    public void StartDialogue()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true);
        }

        // Set initial indices to start with the introduction prompt
        currentPromptIndex = introductionPromptIndex;
        currentLineIndex = 0;
        typingCoroutine = StartCoroutine(TypeLine());
    }
    void SwitchToGiveQuestPrompt()
    {
        // Set current prompt index to the index of the give quest prompt
        currentPromptIndex = giveQuestPromptIndex;
        currentLineIndex = 0;
        typingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(string[] lines, float textSpeed)
    {
        textComponent.text = string.Empty;

        if (lines != null && lines.Length > 0)
        {
            foreach (string line in lines)
            {
                foreach (char c in line.ToCharArray())
                {
                    textComponent.text += c;
                    yield return new WaitForSeconds(textSpeed);
                }
            }
        }
    }
}
