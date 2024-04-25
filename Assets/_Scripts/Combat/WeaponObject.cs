using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour //purpose is to handle animation essentially
{
    [SerializeField]
    private WeaponData weapon;
    private SpriteRenderer render;

    [SerializeField]
    private Animator anim;

    private bool inAttack = false;

    //for weapon floating
    private Transform originalLocation;
    private Transform targetLocation;

    public void BeginAbilityAnimation(int id, CombatEnemy enemy) //id is 0 or 1
    {
        if (inAttack) return;

        inAttack = true;

        if (weapon.isRanged)
        {
            anim.SetTrigger(weapon.abilityList[id].name);
        }
        else
        {
            originalLocation = transform;
            targetLocation = enemy.GetComponentInParent<Transform>();
            StartCoroutine(FloatToEnemy());
        }
    }

    IEnumerator FloatToEnemy()
    {
        return null;
    }

    public void Activate(int id) //called via animation events
    {
        weapon.abilityList[id].OnActivated();
    }

    void ReturnToIdle()
    {
        anim.SetTrigger("Idle");
        inAttack = false;
    }
}
