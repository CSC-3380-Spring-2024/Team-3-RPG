using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatTextbox : MonoBehaviour
{
    public TextMeshProUGUI textbox;

    public void ShowText(string text)
    {
        textbox.text = text;
    }
}
