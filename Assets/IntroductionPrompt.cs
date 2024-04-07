// IntroductionPrompt.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntroductionPrompt", menuName = "ScriptableObjects/IntroductionPrompt", order = 1)]
public class IntroductionPrompt : ScriptableObject
{
    public static string[] lines = { "this is the introduction prompt", "hello there nice to meet you", "LSU is in shambles and it is your job to take it out", "you will have quests as we go", "you will also have fights", "good luck" };   // Array of dialogue lines for this prompt
    public float textSpeed;  // Speed at which the text is displayed
}