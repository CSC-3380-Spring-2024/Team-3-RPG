using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : CombatEntity
{
    [SerializeField]
    private SpriteRenderer render;
    private Color originalColor;

    //animation stuff
    [SerializeField]
    private Animator anim;
    private bool inAnim;

    // Start is called before the first frame update
    void Awake()
    {
        maxHealth = 5f;
        currentHealth = maxHealth;
    }

    private void Start()
    {
        healthBar = CombatUIManager.instance.playerHealth;
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
