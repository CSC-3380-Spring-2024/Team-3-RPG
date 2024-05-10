using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PersistentData : MonoBehaviour //only job is to keep its child data as persistent across scenes
{
    [SerializeField]
    private GameObject WorldSceneExclusive;
    [SerializeField]
    private CinemachineVirtualCamera vcam;
    [SerializeField]
    private GameObject player;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += CheckCurrentScene;
    }

    private void CheckCurrentScene(Scene current, Scene next)
    {
        if (next.name.Equals("Combat"))
        {
            WorldSceneExclusive.SetActive(false);
            vcam.Follow = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }
        if (next.name.Equals("WorldScene"))
        {
            WorldSceneExclusive.SetActive(true);
            vcam.Follow = player.transform;
        }
    }
}
