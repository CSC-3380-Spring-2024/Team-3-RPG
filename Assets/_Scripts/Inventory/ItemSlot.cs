using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    /* ITEM DATABASE */     // Change to private once completed; public for testing/debugging
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public Sprite emptySprite;
    public string itemDescription;
    public bool isFull;
    private int maxItem = 99;               // The max amount player can hold an item
    public string emptyText = "";

    /* ITEM SLOT */
    [SerializeField] 
    private TMP_Text quantityText;
    [SerializeField] 
    private Image itemImage;

    /* ITEM DESCRIPTION */
    public GameObject Description;
    public Image descriptionImg;
    public TMP_Text descriptionName;
    public TMP_Text descriptionText;


    public GameObject selectedSlot;         // Game object in Unity Scene
    public bool itemSelected;               // Declare and initialize variables for game state
    private MenuManager inventoryManager;   // Reference to MenuManager.cs

    private void Start() {;
        inventoryManager = GameObject.Find("Canvas").GetComponent<MenuManager>();
    }

    // Sets the item data player obtained
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription) {
        // Checks if slot is full
        // Item will not be picked up
        if(isFull)
            return quantity;
        
        // Updates the item data
        this.itemName = itemName;
        this.quantity += quantity;              // Stacks item if already obtained
        if(this.quantity >= maxItem) {          // Slot is full
            quantityText.text = maxItem.ToString();
            quantityText.enabled = true;        // Turns back hidden quantity text
            isFull = true;

            // Return items that can't be picked up
            int extraItems = this.quantity - maxItem;
            this.quantity = maxItem;
            return extraItems;
        }
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        this.itemDescription = itemDescription;

        // Update quantity text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;            // Turns back hidden quantity text

        return 0;
    }

    // Actions based on mouse left or right click
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left) {
            OnLeftClick();
        }

        if(eventData.button == PointerEventData.InputButton.Right) {
            OnRightClick();
        }
    }

    // Using mouse RIGHT click to use item
    private void OnRightClick()
    {
        throw new NotImplementedException();
        // if(selectedSlot) {
        //     inventoryManager.UseItem(itemName);
        //     this.quantity -= 1;
        //     quantityText.text = this.quantity.ToString();
        //     if(this.quantity <0)
        //         EmptySlot();
        // }
        // else {
        //     inventoryManager.DeselectAllSlots();
        //     selectedSlot.SetActive(true);
        // }
    }

    // Using mouse LEFT click to select a slot
    // Only one slot will be indicated as selected
    private void OnLeftClick()
    {
        inventoryManager.RefeshInventory();
        selectedSlot.SetActive(true);
        itemSelected = true;

        // For the description side of the inventory
        descriptionName.text = itemName;
        descriptionText.text = itemDescription;
        descriptionImg.sprite = itemSprite;

        if (descriptionImg.sprite == null) {
            descriptionImg.sprite = emptySprite;
        }
    }

    /*
    private void EmptySlot() {
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;

        descriptionName.text = "";
        descriptionText.text = "";
        descriptionImg.sprite = itemSprite;

    }
    */
}
