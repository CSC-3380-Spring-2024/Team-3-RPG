using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class DialoguePrompt : ScriptableObject
{
    public string[] introduction = { "this is from the data", "data2", "data3", "data4", "data5" };    // Array of dialogue lines for the IntroductionPrompt
    public float textSpeed;  // Speed at which the text is displayed
}
