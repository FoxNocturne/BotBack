using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Robot : BotBackManager
{
     public Vector3 position { set; get; }
     public bool isWalking { set; get; }
    public Vector2Int mapcoord;
    public TileMapObject tilemap;
    public Sprite visual;
    public Rigidbody rb { get; set; }
    public UnityEvent onDeath = new UnityEvent();
    public UnityEvent onGoal = new UnityEvent();

    public TileObject currentTileObject { get; protected set; }

    private void Awake()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Crée un robot dans la scéne
    /// </summary>
    /// <param name="robot"></param>
    /// <param name="tile"></param>
    /// <returns></returns>
    public static Robot InstantiateObject(Robot robot, TileObject tile)
    {
        Robot instance = GameObject.Instantiate(robot.gameObject, tile.transform.position, tile.transform.rotation).GetComponent<Robot>();
        instance.position = tile.transform.position;
        instance.mapcoord = tile.tileMapPos;
        instance.tilemap = tile.tileMapObject;
        instance.currentTileObject = tile;
        return instance;
    }

    public abstract void GoUp(float size);
    public abstract void GoLeft(float size);
    public abstract void GoRight(float size);
    public abstract void GoDown(float size);

    public abstract void Action();
    public abstract void Stop();
    public abstract void Select();

    public void Death()
    {
        this.onDeath.Invoke();
    }
    
    public  void Goal()
    {
        this.onGoal.Invoke();
    }
}
