using UnityEngine;

public class QuestGiverJLD : MonoBehaviour
{
    // flag to determine if the player is in range
    public bool isPlayerInRange = false;

    // quests that JLD will give us
    public Quest quest1;
    public Quest quest2;
    public Quest quest3;
    public Quest quest4;

    public DialoguePrompt introDialogue;
    public DialoguePrompt TouchGrassDialogue;
    public DialoguePrompt GoblinDialogue;
    public DialoguePrompt SisterCindyDialogue;

    // references
    private QuestManager questManager;
    private DialogueManager dialogueManager;

    private void Awake()
    {
        questManager = QuestManager.Instance;
        dialogueManager = DialogueManager.Instance;
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (questManager != null && !questManager.IsQuestComplete(quest1))
            {
                questManager.CompleteQuest(quest1);
                questManager.DeactivateQuest(quest1);
                DialogueManager.Instance.TriggerDialogue(introDialogue.finishLines);
                Debug.Log($"Quest '{quest1}' has been completed!");
            }

            else if (questManager.IsQuestComplete(quest1))
            {
                // gives first quest
                if (questManager.IsQuestComplete(quest1) && !questManager.quests.Contains(quest2))
                {
                    questManager.AddQuest(quest2);
                    questManager.ActivateQuest(quest2);
                    DialogueManager.Instance.TriggerDialogue(TouchGrassDialogue.lines);
                    Debug.Log($"Quest '{quest2}' has been accepted!");
                }

                // check if quest 1 is complete
                // gives next quest if true
                if (questManager.IsQuestComplete(quest2) && !questManager.quests.Contains(quest3))
                {
                    questManager.AddQuest(quest3);
                    questManager.ActivateQuest(quest3);
                    DialogueManager.Instance.TriggerDialogue(GoblinDialogue.lines);
                    Debug.Log($"Quest '{quest3}' has been accepted!");
                }

                // check if quest 2 is complete
                // gives next quest if true
                if (questManager.IsQuestComplete(quest3) && !questManager.quests.Contains(quest4))
                {
                    questManager.AddQuest(quest4);
                    questManager.ActivateQuest(quest4);
                    DialogueManager.Instance.TriggerDialogue(SisterCindyDialogue.lines);
                    Debug.Log($"Quest '{quest4}' has been accepted!");
                }
            }

            if (questManager.IsQuestComplete(quest4))
            {
                this.enabled = false;
            }
        }

        // checks to see if each quest is active, the player presses E and player is in range
        // if all true, triggers the appropriate dialogue
        if (questManager.IsQuestActive(quest1) && Input.GetKeyDown(KeyCode.E) && isPlayerInRange)
        {
            DialogueManager.Instance.TriggerDialogue(introDialogue.lines);
        }

        if (questManager.IsQuestActive(quest2) && Input.GetKeyDown(KeyCode.E) && isPlayerInRange)
        {
            DialogueManager.Instance.TriggerDialogue(TouchGrassDialogue.lines);
        }

        if (questManager.IsQuestActive(quest3) && Input.GetKeyDown(KeyCode.E) && isPlayerInRange)
        {
            DialogueManager.Instance.TriggerDialogue(GoblinDialogue.lines);
        }

        if (questManager.IsQuestActive(quest4) && Input.GetKeyDown(KeyCode.E) && isPlayerInRange)
        {
            DialogueManager.Instance.TriggerDialogue(SisterCindyDialogue.lines);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}