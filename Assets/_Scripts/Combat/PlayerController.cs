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
    private Tilemap[] collisionTilemap; //Array of collision tilemaps

    public bool isMoving = false;
    private float timeToMove = 0.2f;
    private Vector3 movement = Vector3.zero;
    public bool canMove = true;
    
    // Update is called once per frame
    void Update()
    {
        if (canMove && !isMoving) // Only allow input if not currently moving
        {
            //Vector3 intendedMove = Vector3.zero; // This will store the intended movement direction
            movement = Vector3.zero;
            if (Input.GetKey(KeyCode.W) && !isMoving)
            {
                MovePlayer(Vector3.up);
            }
            if (Input.GetKey(KeyCode.A) && !isMoving)
            {
                MovePlayer(Vector3.left);
            }
            if (Input.GetKey(KeyCode.S) && !isMoving)
            {
                MovePlayer(Vector3.down);
            }
            if (Input.GetKey(KeyCode.D) && !isMoving)
            {
                MovePlayer(Vector3.right);
            }

            if (!isMoving && movement != Vector3.zero) // Check if movement is non-zero before moving
            {
                MovePlayer(movement);
            }
            animator.SetFloat("Horizontal", transform.position.x);
            animator.SetFloat("Vertical", transform.position.y);
            animator.SetFloat("Speed", movement.sqrMagnitude); // Using isMoving to set Speed
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        if (!CanMove(direction)) return;

        StartCoroutine(Move(direction));

    }

    public bool CanMove(Vector3 direction)
    {
        //If there's no tile from the ground tile or if it's a part of the collision map, return false ->can't walk in it.
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        // foreach (Tilemap collisionTilemap in collisionTilemap){
        //     if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
        //     {
        //         return false;
        //     }
        // }
        foreach (Tilemap collisionTilemap in collisionTilemap)
        {
            if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator Move(Vector3 direction) //search up enumerators unity
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