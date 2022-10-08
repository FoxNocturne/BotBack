using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Level", fileName = "Level XX")]
public class LevelScript : ScriptableObject
{
    [SerializeField] private int _tileMapId;
    [SerializeField] private List<Vector2Int> _listSpawnPos;
    [SerializeField] private List<IRobot> _listRobot;

    public int[,] intTileMap { get { return TileMapRepository.instance.GetTileMapById(this._tileMapId); } }
    public List<LevelRobotSpawn> listRobotSpawn
    {
        get {
            List<LevelRobotSpawn> result = new List<LevelRobotSpawn>();
            for (int i = 0; i < this._listSpawnPos.Count; i++)
                result.Add(new LevelRobotSpawn(this._listSpawnPos[i], this._listRobot[i]));
            return result;
        }
    }
}