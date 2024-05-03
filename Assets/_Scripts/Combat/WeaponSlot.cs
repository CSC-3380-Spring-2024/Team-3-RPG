using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    private WeaponData weapon;
    private SpriteRenderer render;

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void SetWeapon(WeaponData weapon)
    {
        this.weapon = weapon;
        render.sprite = weapon.defaultSprite;
    }

    public void UnsetWeapon(WeaponData weapon)
    {
        this.weapon = null;
        render.sprite = null;
    }
}
