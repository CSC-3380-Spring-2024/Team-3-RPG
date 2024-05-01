using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour //purpose is to handle animation essentially
{
    public WeaponData weapon;
    private SpriteRenderer render;

    [SerializeField]
    private Animator anim;

    public bool attackUsed;
    public bool inAttack;

    //for weapon floating
    private Transform originalLocation;
    private Transform targetLocation;
    private bool isFloating = false;

    private void Start()
    {
        attackUsed = false;
        inAttack = false;
        gameObject.SetActive(true);
        anim.enabled = true;
        anim.Rebind();

        render = gameObject.GetComponent<SpriteRenderer>();
        weapon.originalColor = render.color;
    }

    public void resetUse()
    {
        attackUsed = false;
        render.color = weapon.originalColor;
    }

    public void BeginAbilityAnimation(int id, CombatEnemy enemy) //id is 0 or 1
    {
        if (inAttack || attackUsed)
        {
            Debug.Log("already in attack");
            return;
        }

        inAttack = true;

        Debug.Log(weapon.abilityList[id].name);

        if (weapon.isRanged)
        {
            anim.SetTrigger(weapon.abilityList[id].name);
        }
        else
        {
            //Debug.Log("melee attack called");
            originalLocation = transform;
            targetLocation = enemy.GetComponentInParent<Transform>();
            StartCoroutine(PerformAttack(transform.position, enemy.transform.position - new Vector3(1, 0, 0), id));
        }
    }

    public IEnumerator PerformAttack(Vector3 original, Vector3 target, int id)
    {
        if (isFloating) yield break; //float to enemy
        isFloating = true;

        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target, 10f * Time.deltaTime);
            yield return null;
        }

        transform.position = target; //just in case
        isFloating = false;

        anim.SetTrigger(weapon.abilityList[id].name);  //perform attack
        yield return new WaitUntil(() => inAttack == false);

        if (isFloating) yield break; //float back
        isFloating = true;

        while (Vector3.Distance(transform.position, original) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, original, 10f * Time.deltaTime);
            yield return null;
        }

        transform.position = original; //just in case
        isFloating = false;
    }

    public void Activate(int id) //called via animation events
    {
        weapon.abilityList[id].OnActivated();
    }

    void ReturnToIdle() //called via animation events
    {
        render.color = Color.gray;
        anim.SetTrigger("Idle");
        attackUsed = true;
        inAttack = false;
        CombatSystem.instance.selectedEnemy.Deselect();
    }
}
