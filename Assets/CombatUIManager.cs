using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIManager : MonoBehaviour
{
    public static CombatUIManager instance;
    private CombatSystem combatSystem;

    public HealthBar playerHealth;

    public GameObject defaultPanel;
    public GameObject selectWeaponPanel;
    public GameObject selectEnemyPanel;
    public GameObject attackPanel;

    private void Awake()
    {
        if (instance != null && instance != this) //singleton
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        combatSystem = CombatSystem.instance;
    }

    public void ShowAttackingScreen()
    {
        defaultPanel.SetActive(false);
        ShowSelectWeaponPanel();
    }

    public void ShowSelectWeaponPanel()
    {
        selectWeaponPanel.SetActive(true);
    }

    public void SelectWeapon()
    {
        selectWeaponPanel.SetActive(false);
        selectEnemyPanel.SetActive(true);
    }

    public void ShowBag()
    {
        Debug.Log("pressed the bag button");
    }


    public void Flee()
    {
        Debug.Log("pressed the flee button");
    }


}
