using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//responsible for deciding how weapons are slotted into the player's orbit and the orbit of weapons itself

public class PlayerWeaponManager : MonoBehaviour
{
    public static PlayerWeaponManager instance;

    private CombatSystem combatSystem;

    [SerializeField]
    private Transform parent;

    public GameObject[] weapons; //stores the created weapons
    private Vector3[] weaponPositions; //all the weapon positionings for the orbit; initialized in DrawOrbit()
    private int index; //used to rotate weapons array

    private int numOfWeapons;
    private float radius = 1f;

    private bool isRotating = false;

    private void Awake()
    {
        if (instance != null && instance != this) //singleton
        {
            Debug.Log("attempted to create duplicate PlayerWeaponManager instance");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    //Start is called before the first frame update
    void Start()
    {
        combatSystem = CombatSystem.instance;
        numOfWeapons = combatSystem.numOfWeapons;

        weaponPositions = new Vector3[numOfWeapons];
        weapons = new GameObject[numOfWeapons];

        for (int i = 0; i < numOfWeapons; i++)
        {
            weapons[i] = combatSystem.weapons[i];
        }
        DrawOrbit();
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    weapons[0].transform.RotateAround(transform.position, Vector3.forward, 0.4f);
    //}

    void DrawOrbit() //draws the regular polygon for the weapon placement
    {
        float TAU = 2 * Mathf.PI;

        for (int currentPoint = 0; currentPoint < numOfWeapons; currentPoint++) //numOfWeapons represents how many sides we have
        {
            float currentRadian = ((float)currentPoint / numOfWeapons) * TAU;
            float x = Mathf.Cos(currentRadian) * radius;
            float y = Mathf.Sin(currentRadian) * radius;

            weaponPositions[currentPoint] = new Vector3(x, y, 0) + parent.position;

            weapons[currentPoint] = Instantiate(CombatSystem.instance.weapons[currentPoint], weaponPositions[currentPoint], Quaternion.identity, transform);
            weapons[currentPoint].SetActive(true);
        }

        for (int i = 0; i < numOfWeapons; i++)
        {
            combatSystem.weapons[i] = weapons[i];
        }
        //combatSystem.weapons = weapons; //set combat system's weapons as references to the actual objects now
    }

    public void RotateLeft()
    {
        if (isRotating) return; //if in the action of rotating, dont do it again
        isRotating = true;
        StartCoroutine(RL());
    }

    IEnumerator RR()
    {
        Coroutine a = null;
        for (int i = weapons.Length - 1; i >= 0; i--) //perform the physical rotation
        {
            if (i - 1 < 0)
            {
                index = weapons.Length - 1;
            }
            else
            {
                index = i - 1;
            }
            //weapons[i].GetComponent<WeaponObject>().FloatToPosition(weapons[i].transform.position, weaponPositions[index]);
            a = StartCoroutine(Rotate(weapons[i], weaponPositions[index]));
        }
        yield return a;

        GameObject temp;
        GameObject replace = weapons[weapons.Length - 1];
        for (int i = weapons.Length - 1; i >= 0; i--) //rotates the weapons array accordingly so they line up with the weaponspositions array
        {
            if (i - 1 < 0)
            {
                weapons[weapons.Length - 1] = replace;
            }
            else
            {
                temp = weapons[i - 1];
                weapons[i - 1] = replace;
                replace = temp;
            }
        }
        isRotating = false;

    }

    public void RotateRight()
    {
        if (isRotating) return; //if in the action of rotating, dont do it again
        isRotating = true;
        StartCoroutine(RR());
    }

    IEnumerator RL()
    {
        Coroutine a = null;
        for (int i = 0; i < weapons.Length; i++) //perform the physical rotation
        {
            if (i + 1 >= weapons.Length)
            {
                index = 0;
            }
            else
            {
                index = i + 1;
            }
            //weapons[i].GetComponent<WeaponObject>().FloatToPosition(weapons[i].transform.position, weaponPositions[index]);
            a = StartCoroutine(Rotate(weapons[i], weaponPositions[index]));
        }
        yield return a;

        GameObject temp;
        GameObject replace = weapons[0];
        for (int i = 0; i < weapons.Length; i++) //rotates the weapons array accordingly so they line up with the weaponspositions array
        {
            if (i + 1 >= weapons.Length)
            {
                weapons[0] = replace;
            }
            else
            {
                temp = weapons[i + 1];
                weapons[i + 1] = replace;
                replace = temp;
            }
        }
        isRotating = false;

    }


    IEnumerator Rotate(GameObject obj, Vector3 target)
    {
        //Debug.Log("Rotating " + obj + " from " + obj.transform.position + " to " + target);
        //Debug.Log(obj.transform.position == target);
        while (Vector3.Distance(obj.transform.position, target) > 0.1f)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, target, 8f * Time.deltaTime);
            yield return null;
        }

        obj.transform.position = target; //just in case
    }
}