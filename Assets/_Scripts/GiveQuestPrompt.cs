// GiveQuestPrompt.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GiveQuestPrompt", menuName = "ScriptableObjects/GiveQuestPrompt", order = 1)]//create a scriptable object
public class GiveQuestPrompt : ScriptableObject
{
    public static string[] lines = { "Welcome to this world!", "Seek out the wise Lord Jonathan Lucas Dennington.", "His guidance will unveil your first epic quest.", "Arm yourself and embrace the challenges that await!" };   // Array of dialogue lines for this prompt
    public float textSpeed;  // Speed at which the text is displayed
    //this is for talking to jld
}