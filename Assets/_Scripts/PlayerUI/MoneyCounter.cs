using UnityEngine;
using TMPro;

// Player's coin collection located in HUD
// How much money they got? Maybe 100 if we're nice
public class MoneyCounter : MonoBehaviour
{
    /* COUNTER DATA */
    public static MoneyCounter instance;
    public TMP_Text amtTxt;
    public int currentAmt;

    void Awake() {
        instance = this;
    }

    void Start() {
        amtTxt.text = currentAmt.ToString();
    }

    // Adds collected coin into current amount
    // Player is holding
    public void AddAmt(int amt) {
        currentAmt += amt;
        amtTxt.text = currentAmt.ToString();
    }

}
