using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Sprite defaultSprite; //default sprite
    public Sprite selectedSprite; //white border around sprite for when weapon is selected

    public Ability[] abilityList; //List of usable abilities

    public bool didAction = false;
}
