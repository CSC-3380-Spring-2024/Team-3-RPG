using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOrbit : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Idle() //idle spinning
    {
        transform.position = (Vector2) Vector3.Slerp(new Vector3(0, 0), new Vector3(3, 2), 1);
        yield return null;
    }
    IEnumerator SelectMode() //select mode's spinning
    {
        yield return null;
    }
}
