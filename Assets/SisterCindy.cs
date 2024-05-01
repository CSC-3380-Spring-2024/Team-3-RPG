// SisterCindy.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SisterCindy", menuName = "ScriptableObjects/SisterCindy", order = 1)]
public class SisterCindy : ScriptableObject
{
    public static string[] lines = { "Challenge Sister Cindy!", "Sister Cindy has been a nuisance to our grounds for far too long!", "Get rid of her and get me a margarita.", };   // Array of dialogue lines for this prompt
    public float textSpeed;  // Speed at which the text is displayed
}
