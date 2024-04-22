// GiveQuestPrompt.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GiveQuestPrompt", menuName = "ScriptableObjects/GiveQuestPrompt", order = 1)]
public class GiveQuestPrompt : ScriptableObject
{
    public static string[] lines = { "this is your job now go do it", "Watch out for the dragons!", "The forest can be dangerous.", "We're low on supplies.", "We need someone brave to help us.", "3 for 3 lets go" };   // Array of dialogue lines for this prompt
    public float textSpeed;  // Speed at which the text is displayed
}