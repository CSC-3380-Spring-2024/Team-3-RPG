using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class DialoguePrompt : ScriptableObject
{
    public string[] introduction = { "WELCOME TO ELYSSIU!", "You are a new student of the academy Elyssiu training to become a combat sorcerer/sorceress (CS Major)", "After your orientation, you meet with one of the head wizards, Lord Jonathan Lucas Dennington, who wants to be your personal mentor", "Soon after, you learn you are the fabled hero of a prophecy tasked to slay Mikhail, Beast of the Ancient, located in the Ruins of Tiger Colosseum", "Set forth, unlock the secrets of Elyssiu and fulfill YOUR prophecy!" };    // Array of dialogue lines for the IntroductionPrompt
    public float textSpeed;  // Speed at which the text is displayed
}
