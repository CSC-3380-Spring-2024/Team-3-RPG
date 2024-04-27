// GiveQuestPrompt.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GiveQuestPrompt", menuName = "ScriptableObjects/GiveQuestPrompt", order = 1)]
public class GiveQuestPrompt : ScriptableObject
{
    public static string[] lines = { "Welcome to this world!", "Go talk to John Luke", "After speaking with him, he will unlock your first quest", "prepare yourself" };   // Array of dialogue lines for this prompt
    public float textSpeed;  // Speed at which the text is displayed
}