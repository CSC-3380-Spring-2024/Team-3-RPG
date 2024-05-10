using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows us to create new weapon object
// within Unity through Scriptable Objects
[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory/Items/Weapon")]
public class WeaponObj : ItemSO
{
    private CombatTransitionManager combatTransitionManager;    // Reference CombatTransitionManager.cs
    public GameObject weaponPrefab;    // Stores the associated weapon prefab

    public void Awake() {
        itemType = ItemType.Weapon;
    }

    public override bool UseItem() {
        // Finds Combat Transition Manager in hierarchy
        combatTransitionManager = CombatTransitionManager.instance;
            
        if(combatTransitionManager == null) {
            Debug.Log("Weapon slots currently full!");
            return false;
        }

        // Adds weapon prefab into array
        combatTransitionManager.AddWeapon(weaponPrefab);
        return true;
    }
}
