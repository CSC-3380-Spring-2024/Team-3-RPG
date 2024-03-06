using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D collider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test");
    }
}
