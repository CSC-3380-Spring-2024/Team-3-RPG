using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoblinQuest", menuName = "ScriptableObjects/GoblinQuest", order = 1)] //might have to change this
public class GoblinQuest : ScriptableObject
{
    public static string[] lines = { "hello Goblin", "hello again Goblin" };    // Array of dialogue lines for the IntroductionPrompt
    public static string[] finishGob = { "gob is finished" };
    public float textSpeed;  // Speed at which the text is displayed
}