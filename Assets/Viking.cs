// TouchGrass.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Viking", menuName = "ScriptableObjects/Viking", order = 1)]
public class Viking : ScriptableObject
{
    public static string[] lines = { "hello Viking", "hello again Viking" };    // Array of dialogue lines for the IntroductionPrompt
    public static string[] finishViking = { "you met Viking", "quest done" };
    public float textSpeed;  // Speed at which the text is displayed
}
//make one for goblin and make one with jld  = hello sorcess