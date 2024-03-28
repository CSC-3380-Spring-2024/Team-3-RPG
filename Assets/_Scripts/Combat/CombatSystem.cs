using System.Collections;
using UnityEngine;

public enum CombatState //1 will be reserved for events that happen in the player's turn
{
    START = 0,
    PLAYERTURN = 1,
    SELECTMODE = 1,
    ENEMYTURN = 2,
    WON = 3,
    LOST = 4
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

    public CombatEntity playerCombat;
    CombatEnemy[] enemyCombat; //size will be 6

    public CombatEnemy selectedEnemy;

    public CombatState state;

    public WeaponScriObj[] weaponObjects; //size will be 6
    private Weapon[] weapons; //size will be 6
    public Weapon currentWeapon;

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

        enemyCombat = new CombatEnemy[6];
        for (int i = 0; i < weaponObjects.Length; i++) //initialize weapon array
        {
            if (weaponObjects[i] == null)
            {
                return;
            }
            weapons[i] = weaponObjects[i].weaponData;
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
                enemyCombat[i] = enemy.GetComponent<CombatEnemy>();
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
        EnterEnemyTurn();
    }

    public void Attack()
    {
        if ((int) state != 1) //not in player turn
        {
            return;
        }

        if (selectedEnemy == null) //deal damage to selected enemy
        {
            Debug.Log("no enemy assigned!");
            return;
        }
        Debug.Log("attemping damage");
        selectedEnemy.TakeDamage(2);
        selectedEnemy.Deselect();
        state = CombatState.ENEMYTURN;
    }

    public void EndPlayerTurn() //for skipping turn
    {
        state = CombatState.ENEMYTURN;
    }

    public void SelectEnemy()
    {
        state = CombatState.SELECTMODE;
    }
    #endregion

    #region Enemy Turn

    //IEnumerator EnemyTurn()
    //{
    //    Debug.Log("enemy turn time");
    //    yield return new WaitUntil(() => state != CombatState.ENEMYTURN);
    //}

    void EnterEnemyTurn()
    {
        Debug.Log("enemy turn time");

        //StartCoroutine(EnemyTurn());
        for (int i = 0; i < enemyCombat.Length; i++)
        {
            if (enemyCombat[i] == null)
            {
                return;
            }
            enemyCombat[i].StartTurn();
        }
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

    public void setEnemy(CombatEnemy enemy)
    {
        selectedEnemy = enemy;
    }

    public void unsetEnemy()
    {
        selectedEnemy = null;
    }

    #endregion

}
