using UnityEngine;

[CreateAssetMenu(menuName = "Game/Level", fileName = "Level XX")]
public class LevelScript : ScriptableObject
{
    [SerializeField] private Vector2Int _mapSize;

    public Vector2Int mapSize { get { return this._mapSize; } }
}