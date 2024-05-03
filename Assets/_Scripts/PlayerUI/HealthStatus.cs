using TMPro;
using UnityEngine;

// Player's health status in numbers
// Located in HUD
public class HealthStatus : MonoBehaviour
{
    public TMP_Text healthStatus;           // Health status text
    public PlayerCombat playerHealth;       // Reference PlayerCombat.cs
    // Make sure in Inspector, you link player into the script

    void Start()
    {
        healthStatus.text = playerHealth.currentHealth.ToString();
    }

    void Update()
    {
        healthStatus.text = playerHealth.currentHealth.ToString();
    }

}
