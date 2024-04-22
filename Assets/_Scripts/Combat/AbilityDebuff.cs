using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Ability/Debuff")]
public class AbilityDebuff : Ability
{
    public int duration;

    public override bool OnActivated()
    {
        CombatSystem.instance.selectedEnemy.statuses.Add(name, duration);
        return true;
    }
}
