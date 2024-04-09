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

    public int numOfPanels;
    private GameObject[] panels;

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
        panels = new GameObject[numOfPanels];
        panels[0] = defaultPanel;
        panels[1] = selectWeaponPanel;
        panels[2] = selectEnemyPanel;
        panels[3] = attackPanel;
    }

    private void Start()
    {
        combatSystem = CombatSystem.instance;
        ShowOnly(defaultPanel);
    }

    public void ShowOnly(GameObject panel)
    {
        for (int i = 0; i < numOfPanels; i++)
        {
            if (panels[i] == panel)
            {
                panels[i].SetActive(true);
                continue;
            }
            panels[i].SetActive(false);
        }
    }

    public void ShowAttackingScreen()
    {
        ShowSelectWeaponPanel();
    }

    public void ShowSelectWeaponPanel()
    {
        ShowOnly(selectWeaponPanel);
    }

    public void SelectLeftWeapon()
    {
        PlayerWeaponManager.instance.rotateLeft();
    }

    public void SelectRightWeapon()
    {
        PlayerWeaponManager.instance.rotateRight();
    }

    public void SelectWeapon()
    {
        ShowOnly(selectEnemyPanel);
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
