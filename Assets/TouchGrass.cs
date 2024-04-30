// TouchGrass.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TouchGrass", menuName = "ScriptableObjects/TouchGrass", order = 1)]
public class TouchGrass : ScriptableObject
{
    public static string[] lines = { "touch some grass", "touch grass again1", "touch grass again2", "touch grass again3", "touch grass again4", "touch grass again5" };    // Array of dialogue lines for the IntroductionPrompt
    public float textSpeed;  // Speed at which the text is displayed
}
//make one for goblin and make one with jld  = hello sorcess