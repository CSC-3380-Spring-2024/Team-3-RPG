using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldEntity : MonoBehaviour
{
    public new string name;
    public string description;

    public abstract bool OnActivated(); //returns true if action was successful
}
