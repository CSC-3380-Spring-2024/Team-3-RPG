// IntroductionPrompt.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntroductionPrompt", menuName = "ScriptableObjects/IntroductionPrompt", order = 1)]
public class IntroductionPrompt : ScriptableObject
{
    public static string[] lines = { "Welcome to our village!", "We've been expecting you.", "Please make yourself at home.", "Let me show you around town." };   // Array of dialogue lines for this prompt
    public float textSpeed;  // Speed at which the text is displayed
}