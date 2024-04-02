using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pausePanel;

    /* Player may either click the pause button
        OR press 'esc' to pull up the pause menu */
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    /* Returns back to game state */
    public void ResumeGame() {
        
        pausePanel.SetActive(false);    // Disables GameObject
        Time.timeScale = 1f;    // Unfreezes the game
        isPaused = false;

    }

    /* Stops current game state */
    public void PauseGame() {
        Debug.Log("[*]GAME ON PAUSED...");
        pausePanel.SetActive(true); // Enables GameObject
        Time.timeScale = 0f;    // Complete freezes the game
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
}
