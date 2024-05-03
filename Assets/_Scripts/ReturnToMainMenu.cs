using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public void ReturnToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
