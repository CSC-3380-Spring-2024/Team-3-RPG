using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepsSound;
    [SerializeField]
    public PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (playerController != null && playerController.enabled)
            {
                footstepsSound.enabled = true;
            }
            //if hit wasd and the player can move then make the footsteps sound

        }
        else
        {
            footstepsSound.enabled = false;
            //if not, do not play the footsteps sound
        }

    }
}
