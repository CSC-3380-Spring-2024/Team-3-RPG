using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour //purpose is to handle animation essentially
{
    public WeaponData weapon;
    private SpriteRenderer render;

    [SerializeField]
    private Animator anim;

    public bool inAttack;

    //for weapon floating
    private Transform originalLocation;
    private Transform targetLocation;
    private bool isFloating = false;

    private void Start()
    {
        inAttack = false;
    }
    public void BeginAbilityAnimation(int id, CombatEnemy enemy) //id is 0 or 1
    {
        if (inAttack)
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
            Debug.Log("called");
            originalLocation = transform;
            targetLocation = enemy.GetComponentInParent<Transform>();
            //StartCoroutine(FloatToPosition(transform.position, enemy.transform.position));
            anim.SetTrigger(weapon.abilityList[id].name);
        }
    }

    public IEnumerator FloatToPosition(Vector3 original, Vector3 target)
    {
        if (isFloating) yield break;
        isFloating = true;

        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.5f);
            yield return null;
        }

        transform.position = target; //just in case
        isFloating = false;
    }

    public void Activate(int id) //called via animation events
    {
        weapon.abilityList[id].OnActivated();
    }

    void ReturnToIdle() //called via animation events
    {
        anim.SetTrigger("Idle");
        inAttack = false;
    }
}
