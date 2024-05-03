using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TouchGrass", menuName = "ScriptableObjects/TouchGrass", order = 1)]
public class TouchGrass : ScriptableObject
{
    public static string[] lines = { "Check your screen time", "Go outside and touch some grass" };    // Array of dialogue lines for the IntroductionPrompt
    public static string[] finishGrass = { "Congratulations!", "You touched grass!", "Go back to Jonathan Lucas Dennington to retrieve your next quest" };
    public float textSpeed;  // Speed at which the text is displayed
}
//make one for goblin and make one with jld  = hello sorcess