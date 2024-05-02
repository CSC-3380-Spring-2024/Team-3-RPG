using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap collisionTilemap;

    public bool isMoving = false;
    private float timeToMove = 0.2f;
    private Vector3 movement = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.up; // Add to the movement vector
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.down;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }
        
        if (!isMoving && movement != Vector3.zero) // Check if movement is non-zero before moving
        {
            MovePlayer(movement);
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        //Using magnitude, length of movement vector aka speed
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void MovePlayer(Vector3 direction)
    {
        if (!CanMove(direction)) return;

        StartCoroutine(Move(direction));

    }


    private bool CanMove(Vector3 direction)
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition)) //if the ground doesnt have a tile at the targeted direction OR the collision tile does, return false
        {
            return false;
        }
        return true;
    }

    private IEnumerator Move(Vector3 direction) //search up enumerators unity
    {
        isMoving = true;
        float elapsedTime = 0;
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition + (Vector3)direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / timeToMove)); //smooths the movement
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; //just in case

        isMoving = false;
    }

}
