using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows us to create new miscellaneous item object
// within Unity through Scriptable Objects
[CreateAssetMenu(fileName = "New Miscellaneous Object", menuName = "Inventory/Items/Misc")]
public class MiscObj : ItemSO
{
    public void Awake() {
        itemType = ItemType.Misc;
    }
}
