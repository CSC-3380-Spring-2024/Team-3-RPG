using System.Collections;
using UnityEngine;

public enum CombatState //1 will be reserved for events that happen in the player's turn
{
    START = 0,
    PLAYERTURN = 1,
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
    public GameObject enemyBattleStations; //parent gameobject that has 6 stations
    public Transform[] enemyBattleStationsArray; //size will be 6

    [HideInInspector]
    public CombatEntity playerCombat;
    CombatEnemy[] enemyCombat; //size will be 6

    public Weapon[] weapons; //size will be 6
    public Weapon currentWeapon;
    public int currentWeaponIndex;
    private int numOfWeapons;


    public CombatEnemy selectedEnemy;

    public CombatState state;
    public bool inSelect; //tells if in enemy selection mode

    #region Setup
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

        enemyBattleStationsArray = new Transform[6];

        inSelect = false;

        currentWeaponIndex = 0;
        currentWeapon = weapons[currentWeaponIndex];

        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] == null) break;
            numOfWeapons++;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyBattleStations.transform.childCount; i++)
        {
            enemyBattleStationsArray[i] = enemyBattleStations.transform.GetChild(i);
        }

        state = CombatState.START;
        StartCoroutine(SetupCombat());
    }

    IEnumerator SetupCombat() //uses a coroutine to buffer the setup
                              //set as coroutine because it waits for user to read a potential textbox
                              //need to change back to void when we implement user interaction instead
    {
        GameObject player = Instantiate(playerPrefab, playerBattleStation); //spawn units
        playerCombat = player.GetComponent<CombatEntity>();

        SetupEnemy();

        yield return null; //wait condition if needed

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
            GameObject enemy = Instantiate(enemyPrefab[i], enemyBattleStationsArray[i]);

            if (enemyCombat[i] == null)
            {
                enemyCombat[i] = enemy.GetComponent<CombatEnemy>();
            }
        }
    }
    #endregion

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

    // public void EnterSelectWeapon()
    // public void ConfirmSelectWeapon()

    public void SwapWeapon(int direction) //0 to select the left weapon, 1 to select the right weapon
                                          //should not be called on its own; use the rotate functions in PlayerWeaponManager
    {
        if (direction != 0 && direction != 1)
        {
            Debug.Log("invalid weapon rotation direction!");
            return;
        }
        if (direction == 0) //switch to the weapon on left
        {
            currentWeaponIndex--;
            if (currentWeaponIndex < 0) //needs to loop around
            {
                currentWeaponIndex = numOfWeapons - 1;
            }
            currentWeapon = weapons[currentWeaponIndex];
        } else //switch to the weapon on right
        {
            currentWeaponIndex++;
            if (currentWeaponIndex >= numOfWeapons) //needs to loop around
            {
                currentWeaponIndex = 0;
            }
            currentWeapon = weapons[currentWeaponIndex];
        }
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
        selectedEnemy.TakeDamage(currentWeapon.damage);
        selectedEnemy.Deselect();
        state = CombatState.ENEMYTURN;
    }

    public void EndPlayerTurn() //for skipping turn
    {
        state = CombatState.ENEMYTURN;
    }



    public void EnterSelectEnemy()
    {
        inSelect = true;
    }

    public void ConfirmSelectEnemy()
    {
        inSelect = false;
    }
    #endregion

    #region Enemy Turn



    void EnterEnemyTurn()
    {
        Debug.Log("enemy turn time");
        StartCoroutine(EnemyTurn());

    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("enemy turn coroutine started");
        for (int i = 0; i < enemyCombat.Length; i++)
        {
            if (enemyCombat[i] == null)
            {
                break;
            }
            enemyCombat[i].StartTurn();
            yield return new WaitUntil(() => enemyCombat[i].turnTaken == true);
        }

        for (int i = 0; i < enemyCombat.Length; i++) //reset turn taken
        {
            if (enemyCombat[i] == null)
            {
                break;
            }
            enemyCombat[i].turnTaken = false;
        }
        state = CombatState.PLAYERTURN;
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
        if (selectedEnemy != null)
        {
            enemy.Deselect();
        }
        selectedEnemy = enemy;
    }

    public void unsetEnemy()
    {
        selectedEnemy = null;
    }

    #endregion

}
