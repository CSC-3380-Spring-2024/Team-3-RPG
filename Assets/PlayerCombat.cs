using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Awake()
    {
        health = 5f;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
