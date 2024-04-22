using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Ability/Mark")]
public class AbilityMark : Ability
{
    [SerializeField]
    private string activator; //name of what triggers the mark; exclusively here so programmer can see
    public int duration;

    public override bool OnActivated()
    {
        CombatSystem.instance.selectedEnemy.statuses.Add(name, duration);
        return true;
    }
}
