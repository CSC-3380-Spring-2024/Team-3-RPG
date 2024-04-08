using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class DialoguePrompt : ScriptableObject
{
    public string[] giveQuestLines = { "this is your job now go do it", "oo whoopie you got it done", "ok so this is the next thing the list never ends", "big brain you got #2 done lets go", "yer a wizard", "3 for 3 lets go" };   // Array of dialogue lines for the GiveQuestPrompt
    public string[] introduction = { "this is the introductionprompt", "i am lost as hell", "what lines are they pulling form", "do i have the code to back these up", "because what the fuck", "3 for 3 lets go" };    // Array of dialogue lines for the IntroductionPrompt
    public float textSpeed;  // Speed at which the text is displayed
}
