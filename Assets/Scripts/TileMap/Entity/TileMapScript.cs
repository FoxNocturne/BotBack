using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Tile Map/Script", fileName = "TileMapXX")]
public class TileMapScript : ScriptableObject
{
    [SerializeField] private Vector2Int _mapSize;
    [SerializeField] private GameObject[,] _tileMap;

    public Vector2Int mapSize { get { return this._mapSize; } }
    public GameObject[,] tileMap { get { return this._tileMap; } }
}