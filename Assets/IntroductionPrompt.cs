// IntroductionPrompt.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntroductionPrompt", menuName = "ScriptableObjects/IntroductionPrompt", order = 1)]
public class IntroductionPrompt : ScriptableObject
{
    public static string[] lines = { "WELCOME TO ELYSSIU!", "You are a new student of the academy Elyssiu training to become a combat sorcerer/sorceress (CS Major)", "After your orientation, you meet with one of the head wizards, Lord Jonathan Lucas Dennington.", "Lord Jonathan Lucas Dennington wants to be your personal mentor.", "Soon after, you learn you are the fabled hero of a prophecy tasked to slay Sister Cindy.", "Set forth, unlock the secrets of Elyssiu and fulfill YOUR prophecy!", "Welcome to this world!", "Seek out the wise Lord Jonathan Lucas Dennington.", "His guidance will unveil your first epic quest.", "Arm yourself and embrace the challenges that await!" };    // Array of dialogue lines for the IntroductionPrompt

    public static string[] introDone = { "You have completed your first quest!", "Continue with Jonathan Lucas Dennington to progress through your journey" };
    public float textSpeed;  // Speed at which the text is displayed
}
//make one for goblin and make one with jld  = hello sorcess