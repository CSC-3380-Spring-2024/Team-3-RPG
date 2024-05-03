using UnityEngine;
using UnityEngine.SceneManagement;  

/* HUD management: world map, inventory, pause screen
    This is also mostly inventory management (sorry, i just dumped it here) */
public class HUDManager : MonoBehaviour
{
    // Game object in Unity Scene (Look at Inspector under "Canvas" in Hierarchy)
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public GameObject mapPanel;

    // Declare and initialize variables for game state
    private bool isPaused = false;
    public bool isInvenOpen = false;
    private bool isMapOpen = false;

    /* INVENTORY DATA */
    public ItemSlot[] itemSlot;     // Number of slots avaliable in inventory
    public ItemSO[] itemSO;         // Item Scriptable Objects

    /* Instance */
    public static HUDManager instance;
    
    private void Awake() {
        if(instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    // Player may either click the buttons
    // OR press a key on keyboard to pull up the menu
    void Update()
    {
        // PAUSE MENU toggle
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused)
                ResumeGame();
            else {
                if(!isMapOpen && !isInvenOpen)
                    PauseGame();
            }
        }

        // INVENTORY toggle
        if(Input.GetKeyDown(KeyCode.I)) {
            if(isInvenOpen)
                CloseInven();
            else {
                if(!isMapOpen && !isPaused)
                    OpenInven();
            }
        }

        // MAP toggle
        if(Input.GetKeyDown(KeyCode.M)) {
            if(isMapOpen)
                CloseMap();
            else {
                if(!isInvenOpen && !isPaused)
                    OpenMap();
            }
        }
    }

    /******************************************/
    /*             PAUSE MENU                 */
    /******************************************/
    // Returns back to game state
    public void ResumeGame() {
        pausePanel.SetActive(false);    // Disables GameObject
        Time.timeScale = 1f;            // Unfreezes the game
        isPaused = false;

    }

    // Stops current game state
    public void PauseGame() {
        pausePanel.SetActive(true);    // Enables GameObject
        Time.timeScale = 0f;           // Complete freezes the game
        isPaused = true;
    }

    // Turns off game completely
    public void QuitGame() {
        Debug.Log("[*]QUITTING GAME...");
        Application.Quit();
    }

    /******************************************/
    /*              INVENTORY                 */
    /******************************************/
    // Opens inventory menu
    public void OpenInven() {
        inventoryPanel.SetActive(true);
        Time.timeScale = 0f;
        isInvenOpen = true;
        RefeshInventory();
    }

    // Closes inventory menu
    public void CloseInven() {
        inventoryPanel.SetActive(false);
        Time.timeScale = 1f;
        isInvenOpen = false;
    }

    // Use the items in the player's inventory
    public bool UseItem(string itemName) {
        // Looks through array of Scriptable Objects items
        for(int i = 0; i < itemSO.Length; i++) {
            if(itemSO[i].itemName == itemName) {
                bool usable = itemSO[i].UseItem();
                return usable;
            }
        }

        return false;
    }

    // Adds item into player's inventory
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        // Loops though slots in inventory
        for(int i = 0; i < itemSlot.Length; i++)
            // Adds item into a slot if there's an empty slot
            if(itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0) {
                int maxStackItem = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);

                if(maxStackItem > 0)   // There is leftover items
                    maxStackItem = AddItem(itemName, maxStackItem, itemSprite, itemDescription);
                // or just use return for a single slot holding one item (like zelda's inven)
                return maxStackItem;
            }
        
        return quantity;
    }

    // Inventory view is reset to default state
    public void RefeshInventory() {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedSlot.SetActive(false);
            itemSlot[i].itemSelected = false;
            itemSlot[i].descriptionImg.sprite = itemSlot[i].emptySprite;
            itemSlot[i].descriptionName.text = itemSlot[i].emptyText;
            itemSlot[i].descriptionText.text = itemSlot[i].emptyText;
        }
    }

    /******************************************/
    /*              WORLD MAP                 */
    /******************************************/
    // Opens map
    public void OpenMap() {
        mapPanel.SetActive(true);
        Time.timeScale = 0f;
        isMapOpen = true;
    }

    // Closes map 
    public void CloseMap() {
        mapPanel.SetActive(false);
        Time.timeScale = 1f;
        isMapOpen = false;
    }
}
