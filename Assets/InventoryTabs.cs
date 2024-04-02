using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTabs : MonoBehaviour
{
    // List of inventory categories (buttons to select)
    public List<TabButton> tabButton;

    // Reference TabButton.cs
    public TabButton selectedTab;

    // List of possible Inventory to switch to
    public List<GameObject> swapTab;

    /* Visual differents in selected tab buttons */
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;

    // Takes in the tab that's been clicked on
    public void Select(TabButton button) {
        if(tabButton == null)
            tabButton = new List<TabButton>();
        
        tabButton.Add(button);
    }

    // When user are deciding on which tab to go to but they have clicked on it just yet
    public void EnterTab(TabButton button) {
        ResetTab();

        if(selectedTab == null || button != selectedTab)
            button.bg.sprite = tabHover;
    }

    // When in another tab, it clears out previous content of tab
    public void ExitTab(TabButton button) {
        ResetTab();
    }

    // The current tab selected
    public void SelectedTab(TabButton button) {
        selectedTab = button;
        ResetTab();
        button.bg.sprite = tabActive;

        /* Switching to different Inventory and changing content */
        int index = button.transform.GetSiblingIndex();
        for(int i = 0; i < swapTab.Count; i++) {
            if(i == index)
                swapTab[i].SetActive(true);
            else
                swapTab[i].SetActive(false);
        }
    }

    // Inventory are in idle
    public void ResetTab() {
        foreach(TabButton button in tabButton) {
            // If a tab is selected, it'll display items for the specific category
            if(selectedTab != null && button == selectedTab)
                continue;

            // Only selected tab will be highlighed
            // Everything else is default
            button.bg.sprite = tabIdle;
        }
    }
}
