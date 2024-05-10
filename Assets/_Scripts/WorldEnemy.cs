using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldEnemy : MonoBehaviour
{
    public GameObject[] enemies; //will store enemeis to bring into combatscene
    [SerializeField]
    private PlayerCombat player;

    private bool isPlayerInRange = false;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E)) //transition into combat
        {
            StartCoroutine(StartTransitionToCombat());
        }
    }

    IEnumerator StartTransitionToCombat()
    {
        DontDestroyOnLoad(gameObject);
        CombatTransitionManager.instance.combatEnemies = enemies;
        CombatTransitionManager.instance.currentHealth = player.currentHealth;
        yield return SceneManager.LoadSceneAsync(4);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

}
