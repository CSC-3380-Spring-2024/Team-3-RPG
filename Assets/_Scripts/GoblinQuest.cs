using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoblinQuest", menuName = "ScriptableObjects/GoblinQuest", order = 1)] //might have to change this
public class GoblinQuest : ScriptableObject
{
    public static string[] lines = { "Goblins have invaded! Kill them to show off your strength!" };    // Array of dialogue lines for the IntroductionPrompt
    public static string[] finishGob = { "The goblins are defeated!", "Go back to Jonathan Lucas Dennington to retrieve your next quest." };
    public float textSpeed;  // Speed at which the text is displayed
}