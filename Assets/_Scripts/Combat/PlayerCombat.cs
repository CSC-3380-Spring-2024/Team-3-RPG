using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CombatEntity
{
    [SerializeField]
    private SpriteRenderer render;
    private Color originalColor;

    public bool inWorld;

    // Start is called before the first frame update
    void Awake()
    {
        maxHealth = 20f;
    }

    private void Start()
    {
        currentHealth = CombatTransitionManager.instance.currentHealth;

        if (!inWorld)
        healthBar = CombatUIManager.instance.GetPlayerHealthbar();
    }

    public override void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth/maxHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        Debug.Log("player died");
    }
}
