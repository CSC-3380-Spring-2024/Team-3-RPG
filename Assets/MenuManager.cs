using UnityEngine;

// Use later when there's a main menu screen
// using UnityEngine.SceneManagement;

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
        Debug.Log("[*]GAME ON PAUSED...");
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
        Debug.Log("[*]OPENNING INVENTORY...");
        inventoryPanel.SetActive(true);
        Time.timeScale = 0f;
        isInvenOpen = true;
    }

    // Closes inventory menu
    public void CloseInven() {
        Debug.Log("[*]CLOSING INVENTORY...");
        inventoryPanel.SetActive(false);
        Time.timeScale = 1f;
        isInvenOpen = false;
    }

    /******************************************/
    /*              WORLD MAP                 */
    /******************************************/
    // Opens map
    public void OpenMap() {
        Debug.Log("[*]OPENNING MAP...");
        mapPanel.SetActive(true);
        isMapOpen = true;
    }

    // Closes map 
    public void CloseMap() {
        Debug.Log("[*]CLOSING MAP...");
        mapPanel.SetActive(false);
        isMapOpen = false;
    }
}
