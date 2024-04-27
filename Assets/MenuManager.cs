using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.SceneManagement;  // Use later when there's a main menu screen

/* HUD management: world map, inventory, pause screen
    This is also mostly inventory management (sorry, i just dumped it here) */
public class MenuManager : MonoBehaviour
{
    // Game object in Unity Scene (Look at Inspector)
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public GameObject mapPanel;

    // Declare and initialize variables for game state
    private static bool isPaused = false;
    private static bool isInvenOpen = false;
    private static bool isMapOpen = false;

    /* INVENTORY DATA */
    public ItemSlot[] itemSlot;     // Number of slots avaliable in inventory
    // public ItemSO[] itemSO;
    // public Image descriptionImg;
    // public Sprite emptySprite;
    // public TMP_Text descriptionName;
    // public TMP_Text descriptionText;

    // Player may either click the buttons
    // OR press a key on keyboard to pull up the menu
    void Update()
    {
        // PAUSE MENU toggle
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused)
                ResumeGame();
            else
                PauseGame();
        }

        // INVENTORY toggle
        if(Input.GetKeyDown(KeyCode.I)) {
            if(isInvenOpen)
                CloseInven();
            else
                OpenInven();
        }

        // MAP toggle
        if(Input.GetKeyDown(KeyCode.M)) {
            if(isMapOpen)
                CloseMap();
            else
                OpenMap();
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

    // Returns to the main menu
    public void MainMenu() {
        // SceneManager.LoadScene("MainMenu");
        Debug.Log("[*]RETURNING TO MAIN MENU...");
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

    // public void UseItem(string itemName) {
    //     // Looks through SO array
    //     for(int i = 0; i < itemSO.Length; i++) {
    //         if(itemSO[i].itemName == itemName)
    //             itemSO[i].UseItem();
    //     }
    // }

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
        isMapOpen = true;
    }

    // Closes map 
    public void CloseMap() {
        mapPanel.SetActive(false);
        isMapOpen = false;
    }
}
