// SisterCindy.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SisterCindy", menuName = "ScriptableObjects/SisterCindy", order = 1)]//create a scriptable object
public class SisterCindy : ScriptableObject
{
    public static string[] lines = { "Challenge Sister Cindy!", "Sister Cindy has been a nuisance to our grounds for far too long!", "Get rid of her and get me a margarita.", "But you have to train before defeating her." };// Array of dialogue lines for this prompt
    public float textSpeed;  // Speed at which the text is displayed
    //sister cindy quest
}
