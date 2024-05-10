using UnityEngine;

// For coin object, make sure to add BoxCollider2D onto parent
// This is seperate from other collectibles so remember to add
// a script to parent of coin sprite if using
public class Coin : MonoBehaviour
{
    public int amt = 1;     // Initial amt is 1
                            // However, it can be change via Unity

    // Just like item, if Player (make sure to tag as said)
    // touches the coin, it'll be automatically added
    // to the counter at the top
    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            MoneyCounter.instance.AddAmt(amt);
        }
    }

}
