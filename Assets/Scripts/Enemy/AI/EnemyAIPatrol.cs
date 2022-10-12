using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIPatrol : MonoBehaviour
{
    public EnemyObject host { get; protected set; }
    public List<Vector2Int> listKeyPos { get; protected set; }

    public static EnemyAIPatrol AddBehavior(EnemyObject host, LevelSerializableEnemySpawn strategy)
    {
        EnemyAIPatrol behavior = host.gameObject.AddComponent<EnemyAIPatrol>();
        behavior.host = host;
        behavior.listKeyPos = new List<Vector2Int>();
        foreach (var mapPos in strategy.listKeyPos) {
            behavior.listKeyPos.Add(new Vector2Int(mapPos.x, mapPos.y));
        }
        return behavior;
    }

    public IEnumerator Execute()
    {
        int keyId = 0;
        while (this.gameObject != null) {
            EnemyObject.Direction direction = this.FindDirection(this.listKeyPos[keyId]);
            this.host.SetDirection(direction);
            while (this.host.mapPosition != this.listKeyPos[keyId]) {
                yield return this.host.Move();
            }
            keyId = (keyId + 1) % this.listKeyPos.Count;
        }
    }

    private EnemyObject.Direction FindDirection(Vector2Int targetMapPos)
    {
        Vector2Int offset = targetMapPos - this.host.mapPosition;
        if (offset.x > 0) return EnemyObject.Direction.Right;
        if (offset.x < 0) return EnemyObject.Direction.Left;
        if (offset.y > 0) return EnemyObject.Direction.Up;
        if (offset.y < 0) return EnemyObject.Direction.Down;
        return EnemyObject.Direction.None;
    }
}