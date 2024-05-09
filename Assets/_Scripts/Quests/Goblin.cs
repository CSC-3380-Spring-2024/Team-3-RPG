using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public int health = 100;
    public bool isAlive = true;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0 && isAlive) // Ensure death is triggered only once
        {
            Death(); // Trigger the death process
        }
    }

    public void Death()
    {
        isAlive = false;

        // Notify listeners that this Goblin has died
        QuestEvents.TriggerGoblinDeath(this);

        Destroy(gameObject); // Optional: handle goblin destruction
    }
}
