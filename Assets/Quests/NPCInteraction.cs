using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public bool isPlayerInRange = false;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E)) // Using 'E' as the interact key
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            // Optionally, display an interaction prompt to the player
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // Optionally, hide the interaction prompt
        }
    }

    void Interact()
    {
        // Handle the interaction logic here
        // For example, starting a dialogue or giving a quest
        //Debug.Log("You talked to the NPC!");
    }
}
