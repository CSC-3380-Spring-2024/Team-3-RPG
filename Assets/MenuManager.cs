using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject inventoryPanel;

    public static bool isPaused = false;
    public static bool isInvenOpen = false;

    /* Player may either click the buttons
        OR press a key on keyboard to pull up the menu */
    void Update()
    {
        // PAUSE MENU
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused)
                ResumeGame();
            else
                PauseGame();
        }

        // INVENTORY
        if(Input.GetKeyDown(KeyCode.I))
            if(isInvenOpen)
                CloseInven();
            else
                OpenInven();
    }

    /******************************************/
    /*             PAUSE MENU                 */
    /******************************************/
    /* Returns back to game state */
    public void ResumeGame() {
        
        pausePanel.SetActive(false);    // Disables GameObject
        Time.timeScale = 1f;            // Unfreezes the game
        isPaused = false;

    }

    /* Stops current game state */
    public void PauseGame() {
        Debug.Log("[*]GAME ON PAUSED...");
        pausePanel.SetActive(true);    // Enables GameObject
        Time.timeScale = 0f;           // Complete freezes the game
        isPaused = true;
    }

    /* Returns to the main menu */
    // public void MainMenu() {
    //     SceneManager.LoadScene("MainMenu");
    // }

    /* Turns off game completely */
    public void QuitGame() {
        Debug.Log("[*]QUITTING GAME...");
        Application.Quit();
    }

    /******************************************/
    /*              INVENTORY                 */
    /******************************************/
    public void OpenInven() {
        Debug.Log("[*]OPENNING INVENTORY...");
        inventoryPanel.SetActive(true);
        isInvenOpen = true;
    }

    public void CloseInven() {
        Debug.Log("[*]CLOSING INVENTORY...");
        inventoryPanel.SetActive(false);
        isInvenOpen = false;
    }
}
