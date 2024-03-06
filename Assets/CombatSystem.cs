using System.Collections;
using UnityEngine;

public enum CombatState
{
    START,
    PLAYERTURN,
    SELECTMODE,
    ENEMYTURN,
    WON,
    LOST
}

public class CombatSystem : MonoBehaviour
{
    public static CombatSystem instance;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    CombatEntity playerCombat;
    EnemyCombat enemyCombat;

    public CombatState state;

    public Weapon currentWeapon;
    public EnemyCombat selectedEnemy;

    private void Awake()
    {
        if (instance != null && instance != this) //singleton
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        state = CombatState.START;
        StartCoroutine(SetupCombat());
    }

    IEnumerator SetupCombat() //uses a coroutine to buffer the setup
                              //set as coroutine because it waits for user to read
                              //need to change back to void when we implement user interaction instead
    {
        GameObject player = Instantiate(playerPrefab, playerBattleStation); //spawn units
        playerCombat = player.GetComponent<CombatEntity>();

        GameObject enemy = Instantiate(enemyPrefab, enemyBattleStation);
        enemyCombat = enemy.GetComponent<EnemyCombat>();
        CombatEnemyManager.instance.addEnemy(enemyCombat);

        yield return new WaitForSeconds(2f); //wait

        state = CombatState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {

    }

    public void OnAttackButton()
    {
        if (state != CombatState.PLAYERTURN)
        {
            return;
        }

    }


    void EnemyTurn()
    {

    }


    public void setWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
    }

    public void unsetWeapon()
    {
        currentWeapon = null;
    }

    public void setEnemy(EnemyCombat enemy)
    {
        selectedEnemy = enemy;
    }

    public void unsetEnemy()
    {
        selectedEnemy = null;
    }
    public void Attack()
    {
        if (state != CombatState.PLAYERTURN)
        {
            return;
        }

        if (selectedEnemy != null)
        {
            Debug.Log("attemping damage");
            selectedEnemy.TakeDamage(2);
            return;
        }
        Debug.Log("no enemy assigned!");

    }

}
