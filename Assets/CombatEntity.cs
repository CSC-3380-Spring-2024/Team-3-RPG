using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatEntity : MonoBehaviour
{
    public HealthBar healthBar;

    public float currentHealth;
    public float maxHealth;

    public void DealDamage(CombatEntity c, float damage)
    {
        c.TakeDamage(damage);
    }

    public abstract void TakeDamage(float damage);

    public abstract void Die();
}
