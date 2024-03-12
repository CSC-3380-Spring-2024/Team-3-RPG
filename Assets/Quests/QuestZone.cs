using UnityEngine;

public class QuestZone : MonoBehaviour
{
    public string questTitle; // Ensure this matches the title of the quest to complete

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You made it to the location!");
            QuestManager.Instance.CompleteQuest(questTitle);
            // Optionally, destroy the zone or disable the quest to prevent re-completion
        }
    }
}
