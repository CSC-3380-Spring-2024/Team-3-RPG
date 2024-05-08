using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int numOfEnemies;

    [SerializeField]
    private Transform playerBattleStation;
    [SerializeField]
    private GameObject enemyBattleStations; //parent gameobject that has 6 stations
    private Transform[] enemyBattleStationsArray; //size will be 6

    [HideInInspector]
    public CombatEntity playerCombat;
    public CombatEnemy[] enemyCombat; //size will be 6

    public GameObject[] weapons; //size will be 6
    public GameObject currentWeaponObject;
    public WeaponObject currentWeapon;

    public int currentWeaponIndex;
    public int numOfWeapons;

    public CombatEnemy selectedEnemy;

    public CombatState state;
    public bool inSelect; //tells if in enemy selection mode

    public bool enemyProcessed; //for combat dialogue to read
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

        numOfEnemies = 0;

        enemyCombat = new CombatEnemy[6];

        enemyBattleStationsArray = new Transform[6];

        inSelect = false;

        currentWeaponIndex = 0;

        enemyProcessed = false;

        playerCombat = playerPrefab.GetComponent<PlayerCombat>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(CombatTransitionManager.instance.currentHealth);
        playerCombat.currentHealth = CombatTransitionManager.instance.currentHealth;
        weapons = CombatTransitionManager.instance.weapons;

        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i] == null) break;
            numOfWeapons++;
        }

        enemyPrefab = CombatTransitionManager.instance.combatEnemies;

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
            numOfEnemies++;
        }
    }

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        for (int i = 0; i < enemyBattleStationsArray.Length; i++) //length should be 6
        {
            if (enemyBattleStationsArray[i].childCount == 0)
            {
                GameObject enemy = Instantiate(enemyPrefab, enemyBattleStationsArray[i]);
                if (enemyCombat[i] == null)
                {
                    enemyCombat[i] = enemy.GetComponent<CombatEnemy>();
                }
                numOfEnemies++;
                break;
            }

        }
    }
    #endregion

    #region Player Turn

    void EnterPlayerTurn()
    {
        state = CombatState.PLAYERTURN;

        CombatUIManager.instance.ShowOnly(CombatUIManager.instance.defaultPanel);

        //reset all weapon usedWeapon variables
        for (int i = 0; i < numOfWeapons; i++)
        {
            weapons[i].GetComponent<WeaponObject>().resetUse();
        }

        StartCoroutine(PlayerTurn());
    }

    IEnumerator PlayerTurn() //waits until player turn ends and also checks for 
    {
        bool shouldContinue = false;
        while (state == CombatState.PLAYERTURN) //perpetually check if theres still a living enemy
        {
            shouldContinue = false;
            for (int i = 0; i < enemyCombat.Length; i++)
            {
                if (enemyCombat[i] == null)
                {
                    continue;
                }
                if (!enemyCombat[i].isDead) //if there exists a living enemy, then game isnt over
                {
                    Debug.Log(enemyCombat[i].name + " is still alive");
                    shouldContinue = true;
                    break;
                }
            }
            if (!shouldContinue) //won
            {
                EnterWin();
            }
            yield return null;
        }
        EnterEnemyTurn();
    }

    public void EnterSelectEnemy()
    {
        inSelect = true;
    }

    public void EndSelectEnemy()
    {
        inSelect = false;
    }

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
            Debug.Log("to left");
            currentWeaponIndex--;
            if (currentWeaponIndex < 0) //needs to loop around
            {
                currentWeaponIndex = numOfWeapons - 1;
            }
            SelectWeapon();
        } else //switch to the weapon on right
        {
            Debug.Log("to right");
            currentWeaponIndex++;
            if (currentWeaponIndex >= numOfWeapons) //needs to loop around
            {
                currentWeaponIndex = 0;
            }
            SelectWeapon();
        }
    }

    public bool SelectWeapon() //called by uimanager, true if successful selection
    {
        if (weapons[currentWeaponIndex].GetComponent<WeaponObject>().attackUsed) return false; //dont let them selected used weapon
        currentWeaponObject = weapons[currentWeaponIndex];
        currentWeapon = currentWeaponObject.GetComponent<WeaponObject>();
        return true;
    }

    public bool Attack(int id) //returns true if attack is successful, false if fails
    {
        if ((int) state != 1) //not in player turn
        {
            return false;
        }

        if (selectedEnemy == null) 
        {
            Debug.Log("no enemy assigned!");
            return false;
        }

        currentWeaponObject.GetComponent<WeaponObject>().BeginAbilityAnimation(id, selectedEnemy); //attacks
        return true;
    }

    public void CheckTurnOver()
    {
        //check if all weapon turns are used
        for (int i = 0; i < numOfWeapons; i++)
        {
            if (!weapons[i].GetComponent<WeaponObject>().attackUsed)
            {
                return;
            }
        }

        state = CombatState.ENEMYTURN;
    }

    public void EndPlayerTurn() //for skipping turn
    {
        state = CombatState.ENEMYTURN;
    }

    #endregion

    #region Enemy Turn

    void EnterEnemyTurn()
    {
        Debug.Log("enemy turn time");
        StartCoroutine(ProcessEnemyTurns());
    }

    IEnumerator ProcessEnemyTurns()
    {
        Debug.Log("enemy turn coroutine started");
        for (int i = 0; i < enemyCombat.Length; i++)
        {
            enemyProcessed = false;
            if (enemyCombat[i] == null)
            {
                continue;
            }
            if (enemyCombat[i].isDead)
            {
                continue;
            }
            Debug.Log("yeah");
            enemyCombat[i].StartTurn();
            yield return new WaitUntil(() => enemyCombat[i].turnTaken == true);
            yield return new WaitForSeconds(0.5f);
            enemyProcessed = true;

            if (playerCombat.currentHealth <= 0)
            {
                EnterLoss();
                break;
            }
        }
        enemyProcessed = false;

        for (int i = 0; i < enemyCombat.Length; i++) //reset turn taken on all enemies
        {
            if (enemyCombat[i] == null)
            {
                break;
            }
            enemyCombat[i].turnTaken = false;
        }
        EnterPlayerTurn();
    }

    #endregion

    #region End Conditions

    public void EnterWin()
    {
        state = CombatState.WON;
        //return to world scene
        CombatTransitionManager.instance.combatEnemies = null;
        CombatTransitionManager.instance.currentHealth = playerCombat.currentHealth;
        SceneManager.LoadScene(2);
    }

    public void EnterLoss()
    {
        state = CombatState.LOST;
        SceneManager.LoadScene(2);
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

    public void setWeapon(GameObject weapon)
    {
        currentWeaponObject = weapon;
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
