using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class CollisionTileMapManager : MonoBehaviour
{
    public static CollisionTileMapManager instance;

    public Tilemap groundTilemap;
    public Tilemap[] collisionTilemap;

    private void Awake()
    {
        if (instance != null && instance != this) //singleton
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
