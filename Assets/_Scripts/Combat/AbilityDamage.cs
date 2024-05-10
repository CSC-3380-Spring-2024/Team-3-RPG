using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Ability/Damage")]
public class AbilityDamage : Ability
{
    public float damage;

    public override bool OnActivated()
    {
        if (CombatSystem.instance.selectedEnemy == null)
        {
            Debug.Log("hey theres no enemy selected");
            return false;
        }
        if (needsMarking && !CombatSystem.instance.selectedEnemy.CheckEffect(markName)) //fails when needs marking and there exists no mark
        {
            Debug.Log("mark not applied!");
            return false;
        }
        CombatSystem.instance.selectedEnemy.TakeDamage(damage);
        if (needsMarking) //remove mark if there exists
        {
            CombatSystem.instance.selectedEnemy.RemoveEffect(markName);
        }
        return true;
    }
}
