using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue")]
public class DialoguePrompt : ScriptableObject
{
    public string[] lines;    // Array of dialogue lines
    public string[] finishLines;
}