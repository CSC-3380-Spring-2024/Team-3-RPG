using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows us to create new weapon object
// within Unity through Scriptable Objects
[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory/Items/Weapon")]
public class WeaponObj : ItemSO
{
    private CombatTransitionManager combatTransitionManager;    // Reference CombatTransitionManager.cs
    [SerializeField]
    private GameObject weaponPrefab;    // Stores the associated weapon prefab

    public void Awake() {
        itemType = ItemType.Weapon;
    }

    public override bool UseItem() {
        Debug.Log("You equipped a weapon!");
        
        combatTransitionManager = CombatTransitionManager.instance;
                
        if(combatTransitionManager == null) {
            Debug.Log("Weapon slots currently full!");
            return false;
        }

        combatTransitionManager.AddWeapon(weaponPrefab);
        return true;
    }
}
