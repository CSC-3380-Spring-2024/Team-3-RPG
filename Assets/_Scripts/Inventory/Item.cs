using UnityEngine;

public class Item : MonoBehaviour
{
    private HUDManager inventoryManager;   // References HUDManager.cs
    public ItemSO itemSO;                   // References ItemSO.cs

    void Start() {
        inventoryManager = GameObject.Find("HUD").GetComponent<HUDManager>();
    }

    // Item must have a Box Collider 2D for this to work
    // Play can interact with object by touching (colliding) it
    public void OnCollisionEnter2D(Collision2D collision) {
        // Make sure to tag player sprite as "Player" in Inspector
        // If the object touches "Player", item will be added into inventory
        if(collision.gameObject.CompareTag("Player")) {
            int maxStackItem = inventoryManager.AddItem(itemSO.itemName, itemSO.quantity, itemSO.itemSprite, itemSO.itemDescription);
            if(maxStackItem <= 0)
                Destroy(gameObject);
            else
                itemSO.quantity = maxStackItem;
        }
    }
}
