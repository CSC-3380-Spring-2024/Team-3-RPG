using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}

public class CombatSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    CombatEntity playerCombat;
    CombatEntity enemyCombat;

    public CombatState state;

    // Start is called before the first frame update
    void Start()
    {
        state = CombatState.START;
        StartCoroutine(SetupCombat());
    }

    IEnumerator SetupCombat() //uses a coroutine to buffer the setup
    {
        GameObject player = Instantiate(playerPrefab, playerBattleStation); //spawn units
        playerCombat = player.GetComponent<CombatEntity>();

        GameObject enemy = Instantiate(enemyPrefab, enemyBattleStation);
        enemyCombat = enemy.GetComponent<CombatEntity>();

        yield return new WaitForSeconds(2f);

        state = CombatState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {

    }

    void EnemyTurn()
    {

    }

}
