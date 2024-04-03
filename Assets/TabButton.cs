using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Image component for background
[RequireComponent(typeof(Image))]

public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public InventoryTabs tabs;      // Reference to InventoryTabs.cs
    public Image bg;                // Allowing image changes
    
    /* Using the event system to change the appearance of inventory
        depending on which tab is selected */ 
    public void OnPointerClick(PointerEventData eventData) {
        tabs.SelectedTab(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabs.EnterTab(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabs.ExitTab(this);
    }

    // Selecting a tab in inventory menu
    // Ensures Image is present before accessing
    public void Awake() {
        bg = GetComponent<Image>();
        tabs.Select(this);
    }


}
