using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Use this to load scenes
public class DiedScene : MonoBehaviour
{
    //Function for the button to load the main menu
    public void Retry(){
        //Load the next scene.
        SceneManager.LoadScene(0); //Loads the next level in the queue
     }
}
