using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows us to create new weapon object
// within Unity through Scriptable Objects
[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory/Items/Weapon")]
public class WeaponObj : ItemSO
{
    public void Awake() {
        itemType = ItemType.Weapon;
    }

    public override bool UseItem() {
        return true;
    }
}