using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : CombatEntity
{

    // Start is called before the first frame update
    void Awake()
    {
        health = 3;
    }

    public override void Die()
    {
        Debug.Log("player wins");
    }
}
