using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisterCinderBoss : CombatEnemy
{
    [SerializeField]
    GameObject rockGolem;
    private int minionsAlive = 0;

    public override void StartTurn()
    {
        //if less than 2-3 minions are alive spawn another
        if (minionsAlive < 2 && CombatSystem.instance.numOfEnemies + 1 <= 6)
        {
            minionsAlive++;
            anim.SetTrigger("Spawn");
        }
        //else, attack
        else
        {
            Attack();
        }

    }

    void SpawnRockGolem() //returns true if spawn was successful
    {
        CombatSystem.instance.SpawnEnemy(rockGolem);
    }
}
