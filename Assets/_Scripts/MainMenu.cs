using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //If you want to change scenes in unity, use this
public class MainMenu : MonoBehaviour{
     public void PlayButton(){
        //Load the next scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Loads the next level in the queue
     }

     public void ExitButton(){
        Debug.Log("Exited");
        Application.Quit();
     }
}
