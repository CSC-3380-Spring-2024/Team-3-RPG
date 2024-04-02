using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;

    public Sprite defaultSprite; //default sprite
    public Sprite selectedSprite; //white border around sprite for when weapon is selected

    public Ability[] abilityList; //List of usable abilities

    public bool didAction = false;
}
