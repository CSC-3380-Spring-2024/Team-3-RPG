using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows us to create new consumable object
// within Unity through Scriptable Objects
[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory/Items/Consumable")]
public class ConsumableObj : ItemSO
{
    public int restoreHealth;
    public int attackBonus;
    public void Awake() {
        itemType = ItemType.Consumable;
    }
}
