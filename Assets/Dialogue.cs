/**

//THIS WORKS FOR THE BARE MINIMUM
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    // Start is called before the first frame update


    void Start()
    {
        if (textComponent == null)
        {
            Debug.LogError("TextMeshProUGUI component is not assigned to textComponent field in the Inspector.");
            return;
        }
        gameObject.SetActive(false);//maybe make this not happen
        textComponent.text = string.Empty;
        startDialogue();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

    }
}
**/



/**
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox; // Reference to the dialogue box GameObject
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false); // Hide the dialogue box initially
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the dialogue is already finished
            if (index < lines.Length)
            {
                // Display next line of dialogue
                StartDialogue();
            }
            else
            {
                // Dialogue is finished, reset index and clear text
                index = 0;
                textComponent.text = string.Empty;

                if (dialogueBox != null)
                {
                    dialogueBox.SetActive(false); // Hide the dialogue box when dialogue is finished
                }
            }
        }
    }

    void StartDialogue()
    {
        // Activate the dialogue box
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true);
        }

        // Stop all coroutines to prevent multiple dialogues from overlapping
        StopAllCoroutines();

        // Display the next line of dialogue
        StartCoroutine(TypeLine());

        // Increment index for the next line
        index++;
    }

    IEnumerator TypeLine()
    {
        // Clear text before typing the new line
        textComponent.text = string.Empty;

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
**/

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
    public string[] lines;
    public float textSpeed;
    private int index;



    void Start()
    {
        Debug.Log("where is this statement???");
        if (dialogueBox != null)
        {
            Debug.Log("Some foo was very angry with boo");

            dialogueBox.SetActive(false); // Hide the dialogue box initially
        }
        // Add a listener to yourButton's onClick event
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(StartDialogue);
        }
        Debug.Log("this is the outside???");
    }

    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     StartDialogue(); // Start the dialogue when mouse button is clicked
        // }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Skip the current line of dialogue and proceed to the next one
            TypeLine();
        }
    }

    void StartDialogue()
    {
        Debug.Log("Button clicked! Starting dialogue...");
        // Activate the dialogue box GameObject
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true);
        }

        // Stop all coroutines to prevent multiple dialogues from overlapping
        StopAllCoroutines();

        // Start typing out the dialogue lines
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        index = 0;
        while (index < lines.Length)
        {
            // Clear text before typing the new line
            textComponent.text = string.Empty;

            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

            index++;
        }

        // Hide the dialogue box when dialogue is finished
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }
}
