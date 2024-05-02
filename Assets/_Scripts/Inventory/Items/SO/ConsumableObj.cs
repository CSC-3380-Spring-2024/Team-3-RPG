using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows us to create new consumable object
// within Unity through Scriptable Objects
[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory/Items/Consumable")]
public class ConsumableObj : ItemSO
{
    /* Possible item stat changes */
    public int restoreHealth;       // Heal
    public int attackBonus;         // Buff
    public int debuffDmg;           // Debuff

    private PlayerCombat healPlayer;    // Reference player in PlayerCombat.cs

    public void Awake() {
        itemType = ItemType.Consumable;
    }

    // Item used will heal player
    public override bool UseItem() {
        /******************************************/
        /*               HEALING                  */
        /******************************************/
        // Get player's heal status (max and current health)
        healPlayer = GameObject.Find("Player").GetComponent<PlayerCombat>();

        // Player cannot heal if they're at max health
        if((healPlayer.currentHealth + restoreHealth) > healPlayer.maxHealth) {
            Debug.Log("Cannot be healed");
            return false;
        }
        // Restores player health based on item's heal amount
        healPlayer.currentHealth += Mathf.Clamp(restoreHealth, 0, healPlayer.maxHealth);
        Debug.Log("You healed! with " + restoreHealth + " Now at: " + healPlayer.currentHealth);

        return true;
    }
}
