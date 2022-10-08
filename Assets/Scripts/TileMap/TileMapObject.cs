using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapObject : MonoBehaviour
{
    public Vector2Int size { get; protected set; }
    public GameObject tilePrefab;
    public TileObject[,] tileMap { get; protected set; }

    public void Start()
    {
        this.InstantiateTileMap(new Vector2Int(10, 30));
    }

    public TileObject[,] InstantiateTileMap(Vector2Int mapSize)
    {
        this.size = mapSize;
        this.tileMap = new TileObject[mapSize.x, mapSize.y];
        for (int x = 0; x < mapSize.x; x++)
            for (int y = 0; y < mapSize.y; y++)
                this.tileMap[x, y] = TileObject.InstantiateObject(this.tilePrefab, this, new Vector2Int(x, y));
        return this.tileMap;
    }

    void OnDrawGizmos()
    {
        // Allows us to visualize where the patrolling points are
        Gizmos.color = Color.cyan;

        Gizmos.DrawWireCube(transform.position + new Vector3(4.5f, -.05f, 4.5f), new Vector3(10f, .1f, 10f));
    }
}
