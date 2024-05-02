using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap collisionTilemap;

    public bool isMoving = false;
    private float timeToMove = 0.2f;

    public bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
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
        }
    }

    private void MovePlayer(Vector2 direction)
    {
        if (!CanMove(direction)) return;

        StartCoroutine(Move(direction));

    }


    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition)) //if the ground doesnt have a tile at the targeted direction OR the collision tile does, return false
        {
            return false;
        }
        return true;
    }

    private IEnumerator Move(Vector2 direction) //search up enumerators unity
    {
        isMoving = true;
        float elapsedTime = 0;
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition + (Vector3)direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / timeToMove)); //smooths the movement
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; //just in case

        isMoving = false;
    }

}
