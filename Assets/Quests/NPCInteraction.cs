using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    // flag to determine if the player is in range
    public bool isPlayerInRange = false;

    // specific quest to give to player
    public Quest questToActivate;

    // QuestManager reference
    private QuestManager questManager;

    private void Awake()
    {
        questManager = QuestManager.Instance;
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (questManager != null && !questManager.quests.Contains(questToActivate))
            {
                questManager.AddQuest(questToActivate);
                Debug.Log($"Quest '{questToActivate}' has been accepted!");
                this.enabled = false;
            }
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