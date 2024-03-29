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

    public bool turnTaken;

    // Start is called before the first frame update
    void Awake()
    {
        maxHealth = 3f;
        currentHealth = maxHealth;
        originalColor = render.color;

        turnTaken = false;

        button.onClick.AddListener(() => Select());
    }

    public void StartTurn()
    {
        Attack();
        //StartCoroutine(TakeTurn());
    }

    //IEnumerator TakeTurn()
    //{
    //    yield return null;
    //}

    private void Attack()
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
    }



    #region Selecting

    public void Select()
    {
        if (!CombatSystem.instance.inSelect)
        {
            Debug.Log("not in select mode!");
            return;
        }

        Debug.Log("selected");
        render.color = Color.red;
        CombatSystem.instance.setEnemy(this);
    }

    public void Deselect()
    {
        Debug.Log("unselected");
        render.color = originalColor;
        CombatSystem.instance.unsetEnemy();
    }

    #endregion
}
