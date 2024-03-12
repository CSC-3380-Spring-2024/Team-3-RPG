using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest questToGive;

    private void Start()
    {
        // Example quest setup
        questToGive = new Quest("go here", "Go to the marked location.", QuestType.Location);
    }

    // Detect player interaction (simplified version)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure your player GameObject has the "Player" tag
        {
            GiveQuest();
        }
    }

    void GiveQuest()
    {
        QuestManager.Instance.AddQuest(questToGive.title, questToGive.description, questToGive.questType,  questToGive.targetLocation);
        // Notify the player via UI or other means
    }
}
