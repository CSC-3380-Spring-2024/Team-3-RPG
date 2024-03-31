using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pausePanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // Returns back to game state
    public void ResumeGame() {
        pausePanel.SetActive(false);
        // Unfreezes the game
        Time.timeScale = 1f;
        isPaused = false;

    }

    // Stops the current game state
    public void PauseGame() {
        // Enables GameObject
        pausePanel.SetActive(true);
        // Complete freezes the game
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void QuitGame() {
        Debug.Log("[*] Quitting game");
        Application.Quit();
    }
}
