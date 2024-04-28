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

    private GameObject[] weapons; //stores the created weapons
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
        DrawOrbit();
    }

    // Update is called once per frame
    void Update()
    {
    }

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
            weapons[currentPoint].transform.Translate(3f, 0, 0);
        }
    }

    public void RotateLeft()
    {
        if (isRotating) return; //if in the action of rotating, dont do it again
        Debug.Log("rotate called");
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
            weapons[i].GetComponent<WeaponObject>().FloatToPosition(weapons[i].transform.position, weaponPositions[index]);
        }
        //weaponSlot.SetWeapon(combatSystem.currentWeapon);
    }

    IEnumerator Rotate(GameObject obj, Vector3 original, Vector3 target)
    {
        Debug.Log("Rotating " + obj + " from " + original + " to " + target);
        Debug.Log(obj.transform.position == target);

        isRotating = true;
        while (obj.transform.position != target)
        {
            obj.transform.RotateAround(parent.position, Vector3.forward, 0.5f);
            yield return null;
        }

        obj.transform.position = target; //just in case
        Debug.Log(obj.transform);
        isRotating = false;
        yield return null;
    }

    //public void rotateRight()
    //{
    //    combatSystem.SwapWeapon(1); //performs the actual game system rotation
    //    weaponSlot.SetWeapon(combatSystem.currentWeapon);
    //}

}