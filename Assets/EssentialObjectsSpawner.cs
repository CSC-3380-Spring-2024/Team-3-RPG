using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialObjectsSpawner : MonoBehaviour
{
    [SerializeField] GameObject essentialObjectsPrefab;

    private void Awake()
    {
        var existingObjects = FindObjectsOfType<PersistentData>();
        if (existingObjects.Length == 0)
        {
            Instantiate(essentialObjectsPrefab, new Vector3(2.257163f, 4.304863f, 12.97192f), Quaternion.identity);
        }
    }
}
