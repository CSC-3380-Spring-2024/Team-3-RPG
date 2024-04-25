//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

////responsible for deciding how weapons are slotted into the player's orbit and the orbit of weapons itself

//public class PlayerWeaponManager : MonoBehaviour
//{
//    public static PlayerWeaponManager instance;

//    private CombatSystem combatSystem;
//    [SerializeField]
//    private GameObject parent;

//    public WeaponSlot weaponSlot;

//    private Transform[] weaponSlots;
//    private WeaponData[] weapons; //reference to combat system's weapons

//    private void Awake()
//    {
//        if (instance != null && instance != this) //singleton
//        {
//            Debug.Log("attempted to create duplicate PlayerWeaponManager instance");
//            Destroy(this);
//        }
//        else
//        {
//            instance = this;
//        }
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        combatSystem = CombatSystem.instance;
//        weapons = CombatSystem.instance.weapons;
//    }

//    //// Update is called once per frame
//    //void Update()
//    //{
        
//    //}

//    public void rotateLeft()
//    {
//        combatSystem.SwapWeapon(0); //performs the actual game system rotation
//        weaponSlot.SetWeapon(combatSystem.currentWeapon);
//    }

//    public void rotateRight()
//    {
//        combatSystem.SwapWeapon(1); //performs the actual game system rotation
//        weaponSlot.SetWeapon(combatSystem.currentWeapon);
//    }


    //    IEnumerator Idle() //idle spinning
    //    {
    //        transform.position = (Vector2) Vector3.Slerp(new Vector3(0, 0), new Vector3(3, 2), 1);
    //        yield return null;
    //    }
    //    IEnumerator SelectMode() //select mode's spinning
    //    {
    //        yield return null;
//    //    }
//}
