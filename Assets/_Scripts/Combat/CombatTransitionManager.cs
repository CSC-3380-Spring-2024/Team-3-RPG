using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTransitionManager : MonoBehaviour { //class is responsible for bringing data back and forth from combat scene
    public static CombatTransitionManager instance;

    public GameObject[] combatEnemies;
    public GameObject[] weapons;
    public float currentHealth;

    bool inCombat = false;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject); //allow for persistence
        if (instance != null && instance != this) //singleton
        {
            Debug.Log("attempted to create duplicate CombatTransitionManager instance");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
}
