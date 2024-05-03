using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapon")]
public class WeaponData : ScriptableObject
{
    public new string name;

    public Sprite defaultSprite; //default sprite
    public Color originalColor; //white border around sprite for when weapon is selected

    public Ability[] abilityList = new Ability[2]; //List of usable abilities

    public bool isRanged = false;
}
