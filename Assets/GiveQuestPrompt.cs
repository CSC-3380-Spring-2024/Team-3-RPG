// GiveQuestPrompt.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GiveQuestPrompt", menuName = "ScriptableObjects/GiveQuestPrompt", order = 1)]
public class GiveQuestPrompt : ScriptableObject
{
    public string[] lines = { "Watch out for the dragons!", "The forest can be dangerous.", "We're low on supplies.", "We need someone brave to help us." };   // Array of dialogue lines for this prompt
    public float textSpeed;  // Speed at which the text is displayed
}