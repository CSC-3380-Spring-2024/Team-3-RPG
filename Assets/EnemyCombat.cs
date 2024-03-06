using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCombat : CombatEntity
{
    public Button button;
    // Start is called before the first frame update
    void Awake()
    {
        maxHealth = 3f;
        currentHealth = maxHealth;

        button.onClick.AddListener(() => Select());
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
        Debug.Log("player wins");
    }

    public void Select()
    {
        Debug.Log("selected");
        CombatSystem.instance.setEnemy(this);
    }
}
