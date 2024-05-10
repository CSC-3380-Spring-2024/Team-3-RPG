using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public Tilemap groundTilemap;
    public Tilemap[] collisionTilemap; //Array of collision tilemaps

    public bool isMoving = false;
    private float timeToMove = 0.2f;
    private Vector3 movement = Vector3.zero;

    private void Start()
    {
        groundTilemap = CollisionTileMapManager.instance.groundTilemap;
        collisionTilemap = CollisionTileMapManager.instance.collisionTilemap;
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionTileMapManager.instance != null)
        {
            groundTilemap = CollisionTileMapManager.instance.groundTilemap;
            collisionTilemap = CollisionTileMapManager.instance.collisionTilemap;
        }

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
        //If there's no tile from the ground tile or if it's a part of the collision map, return false ->can't walk in it.
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);

        foreach (Tilemap collisionTilemap in collisionTilemap){ //For each tilemap labeled for collisions
            //If there's no ground tile to walk on or if there's a tile that belongs to the collisions
            if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
            {
                return false; //Do not walk
            }
        }

        //Checks the future position based on where the player is and direction it will go
        //Uses OverlapBoxAll check with an invis box w/ width and height of 0.75
        //And goes over through all Collider2D objects that overlap
        Vector2 checkPosition = transform.position + direction; 
        Collider2D[] colliders = Physics2D.OverlapBoxAll(checkPosition, new Vector2(0.75f, 0.75f), 0);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("NPC")) //If a collider that overlapped has the tag "NPC"
            {
                return false; //There's an NPC in the way, do not walk through.
            }
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
