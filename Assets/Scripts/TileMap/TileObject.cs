using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    public TileMapObject tileMapObject { get; protected set; }
    public Vector2Int tileMapPos { get; protected set; }

    public TileObject InstantiateObject(GameObject prefab, TileMapObject tileMap, Vector2Int mapPos)
    {
        TileObject instance = GameObject.Instantiate(prefab, tileMap.transform).GetComponent<TileObject>();
        instance.tileMapObject = tileMap;
        instance.tileMapPos = mapPos;
        return instance;
    }
}
