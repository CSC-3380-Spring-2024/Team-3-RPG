using UnityEngine;

// Types of item player can obtain in game
public enum ItemType {
    Weapon,
    Consumable,
    Misc
}

public class ItemSO : ScriptableObject
{ 
    /* ITEM DATA */
    [SerializeField] public string itemName;
    public ItemType itemType;
    public int quantity = 1;
    [SerializeField] public Sprite itemSprite;
    [TextArea(5,10)][SerializeField] public string itemDescription;
}
