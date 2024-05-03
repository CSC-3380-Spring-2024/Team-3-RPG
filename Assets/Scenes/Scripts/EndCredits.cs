using UnityEngine;
using UnityEngine.SceneManagement;

// Roll end credits!
public class EndCredits : MonoBehaviour
{
    // Player touches the portal
    // which will trigger to the end scene credit
    void OnTriggerEnter2D(Collider2D portal) {
        Debug.Log("You touched the portal!");
        SceneManager.LoadScene(2);
    }
}
