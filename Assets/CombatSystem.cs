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

    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private GameObject[] enemyPrefab; //size will be 6

    public Transform playerBattleStation;
    public Transform[] enemyBattleStation; //size will be 6

    CombatEntity playerCombat;
    EnemyCombat[] enemyCombat; //size will be 6
    
    public CombatState state;

    public Weapon currentWeapon;
    public EnemyCombat selectedEnemy;

    public delegate void inSelectState();
    public inSelectState enterSelect;

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
        enemyCombat = new EnemyCombat[6];
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

        SetupEnemy();

        yield return new WaitForSeconds(2f); //wait

        state = CombatState.PLAYERTURN;
        EnterPlayerTurn();
    }

    private void SetupEnemy()
    {
        for (int i = 0; i < enemyPrefab.Length; i++) //length should be 6
        {
            if (enemyPrefab[i] == null)
            {
                return;
            }
            GameObject enemy = Instantiate(enemyPrefab[i], enemyBattleStation[i]);

            if (enemyCombat[i] == null)
            {
                enemyCombat[i] = enemy.GetComponent<EnemyCombat>();
            }
        }
    }

    #region Player Turn

    void EnterPlayerTurn()
    {
        StartCoroutine(PlayerTurn());
    }

    IEnumerator PlayerTurn()
    {
        Debug.Log("player turn time");
        yield return new WaitUntil(() => state != CombatState.PLAYERTURN);
        StartCoroutine(EnemyTurn());
    }

    public void Attack()
    {
        if (state != CombatState.PLAYERTURN) //not in player turn
        {
            return;
        }

        if (selectedEnemy != null) //deal damage to selected enemy
        {
            Debug.Log("attemping damage");
            selectedEnemy.TakeDamage(2);
        }
        Debug.Log("no enemy assigned!");

        state = CombatState.ENEMYTURN;
    }

    public void EndPlayerTurn()
    {
        state = CombatState.ENEMYTURN;
    }

    #endregion

    #region Enemy Turn

    IEnumerator EnemyTurn()
    {
        Debug.Log("enemy turn time");
        yield return new WaitUntil(() => state != CombatState.ENEMYTURN);
    }

    void EnterEnemyTurn()
    {
        StartCoroutine(EnemyTurn());
    }

    #endregion

    #region Setters and Getters

    public void setPlayerPrefab(GameObject player)
    {
        this.playerPrefab = player;
    }

    public void setEnemyPrefab(GameObject[] enemy)
    {
        this.enemyPrefab = enemy;
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

    #endregion

}
