using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemyManager : MonoBehaviour
{
    public static CombatEnemyManager instance;
    public EnemyCombat[] enemyList;
    private int listSize;
    private int iterator;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
        listSize = 6;
        enemyList = new EnemyCombat[listSize];
        iterator = 0;
    }

    public void addEnemy(EnemyCombat enemy)
    {
        if (iterator >= listSize - 1)
        {
            Debug.Log("enemy list full!");
            return;
        }
        enemyList[iterator] = enemy;
        iterator++;
    }


}
