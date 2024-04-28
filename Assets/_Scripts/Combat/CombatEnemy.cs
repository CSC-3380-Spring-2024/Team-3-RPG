using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatEnemy : CombatEntity
{
    public Button button;

    [SerializeField]
    private SpriteRenderer render;
    private Color originalColor;

    //animation stuff
    [SerializeField]
    private Animator anim;
    private bool inAnim;

    public Dictionary<string, int> statuses; // keeps track of names and duration of marks, buffs, debuffs

    public bool turnTaken;

    public bool isDead;

    // Start is called before the first frame update
    void Awake()
    {
        maxHealth = 3f;
        currentHealth = maxHealth;
        originalColor = render.color;

        statuses = new Dictionary<string, int>();

        turnTaken = false;

        isDead = false;
    }

    public void StartTurn()
    {
        if (isDead) return;
        Attack();
    }

    private void Attack() //triggers attack animation
    {
        anim.SetTrigger("Attack");
    }

    private void DoDamage() //called in animation
    {
        CombatSystem.instance.playerCombat.TakeDamage(2);
        Debug.Log(CombatSystem.instance.playerCombat.currentHealth);
    }

    private void EndTurn()
    {
        anim.SetTrigger("Idle");
        turnTaken = true;
        foreach (KeyValuePair<string, int> status in statuses) //decrement status effects
        {
            statuses[status.Key]--;
            if (statuses[status.Key] == 0)
            {
                statuses.Remove(status.Key);
            }
        }
    }

    public void AddEffect(string effectName, int duration)
    {
        statuses.Add(effectName, duration);
    }

    public bool CheckEffect(string effectName)
    {
        return statuses.ContainsKey(effectName);
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
        Debug.Log("enemy died");
        anim.SetBool("isDead", true);
        isDead = true;
    }

    #region Selecting

    public void Select()
    {
        if (!CombatSystem.instance.inSelect)
        {
            Debug.Log("not in select mode!");
            return;
        }
        if (CombatSystem.instance.selectedEnemy == gameObject) Deselect();
        //Debug.Log("selected");
        render.color = Color.red;
        //Debug.Log(render.color.ToString());
        CombatSystem.instance.setEnemy(this);
    }

    public void Deselect()
    {
        //Debug.Log("unselected");
        render.color = originalColor;
        CombatSystem.instance.unsetEnemy();
    }

    #endregion

}
