using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIManager : MonoBehaviour //provides functions for all button presses in combat scene
{
    public static CombatUIManager instance;
    private CombatSystem combatSystem;

    [SerializeField] private HealthBar playerHealth;

    [SerializeField] private GameObject defaultPanel;
    [SerializeField] private GameObject selectWeaponPanel;
    [SerializeField] private GameObject attackPanel;

    

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
        panels[2] = attackPanel;
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

    public HealthBar GetPlayerHealthbar()
    {
        return this.playerHealth;
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
        combatSystem.EnterSelectEnemy();
        ShowOnly(attackPanel);
    }

    public void InitializeWeaponAblityButtons()
    {
        combatSystem.currentWeapon.abilityList[0] = null;
    }

    public void AbilityButton()
    {

    }

    public void Attack()
    {
        combatSystem.ConfirmSelectEnemy();
        combatSystem.Attack();
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
