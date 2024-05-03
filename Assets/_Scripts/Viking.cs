using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Viking", menuName = "ScriptableObjects/Viking", order = 1)]
public class Viking : ScriptableObject
{
    public static string[] lines = { "Hello there old viking" };    // Array of dialogue lines for the IntroductionPrompt
    public static string[] finishViking = { "Great job my sorcerer/sorceress!", "You've met the dear old viking", "Go back to Jonathan Lucas Dennington to retrieve your next quest" };
    public float textSpeed;  // Speed at which the text is displayed
}
//make one for goblin and make one with jld  = hello sorcess