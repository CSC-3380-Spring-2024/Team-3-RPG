using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }

    //Creating a coroutine
    IEnumerator LoadLevel(int levelIndex)
    {
        //Play the animation
        transition.SetTrigger("Start");
        //Wait for it to finish
        yield return new WaitForSeconds(transitionTime);
        //Loading the Scene
        SceneManager.LoadScene(levelIndex);
    }
}
