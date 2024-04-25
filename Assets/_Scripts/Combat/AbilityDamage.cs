using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Ability/Damage")]
public class AbilityDamage : Ability
{
    public bool needsMarking; //if enemy needs to be marked before damage is done
    public string markName; //name of the marking ability
    public float damage;

    public override bool OnActivated()
    {
        if (needsMarking && !CombatSystem.instance.selectedEnemy.CheckEffect(markName)) //fails when needs marking and there exists no mark
        {
            Debug.Log("mark not applied!");
            return false;
        }
        CombatSystem.instance.selectedEnemy.TakeDamage(damage);
        if (needsMarking) //remove mark if there exists
        {
            CombatSystem.instance.selectedEnemy.statuses.Remove(markName);
        }
        weapon.didAction = true;
        return true;
    }
}
