using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Robot : BotBackManager
{
    public enum Stat { none, up, down, left, right }

    public Vector3 position { get; protected set; }
    public bool isWalking { get; protected set; }
    public Stat currentStatus { get; protected set; } = Stat.none;
    public float tileSize { get; protected set; }
    public bool isSelected { get; protected set; } = false;

    public Vector2Int mapcoord;
    public TileMapObject tilemap;
    public Sprite visual;
    public PlayerControler game;
    public Rigidbody rb { get; set; }
    public UnityEvent onDeath = new UnityEvent();
    public UnityEvent onGoal = new UnityEvent();
    public GameObject selectT;
    public GameObject selectF;

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
    public static Robot InstantiateObject(Robot robot, TileObject tile, PlayerControler game)
    {
        Robot instance = GameObject.Instantiate(robot.gameObject, tile.transform.position, tile.transform.rotation).GetComponent<Robot>();
        instance.position = tile.transform.position;
        instance.mapcoord = tile.tileMapPos;
        instance.tilemap = tile.tileMapObject;
        instance.game = game;
        game.BotAdd();
        return instance;
    }

    public virtual void GoUp(float size)
    {
        this.currentStatus = Stat.up;
        this.tileSize = size;
    }

    public virtual void GoDown(float size)
    {
        this.currentStatus = Stat.down;
        this.tileSize = size;
    }

    public virtual void GoLeft(float size)
    {
        this.currentStatus = Stat.left;
        this.tileSize = size;
    }

    public virtual void GoRight(float size)
    {
        this.currentStatus = Stat.right;
        this.tileSize = size;
    }

    public virtual void Stop()
    {
        this.currentStatus = Stat.none;
    }

    public abstract void Action();

    public virtual void Select()
    {
        if (this.isSelected) {
            this.selectF.SetActive(true);
            this.selectT.SetActive(false);
            this.isSelected = false;
        }
        else {
            this.selectF.SetActive(false);
            this.selectT.SetActive(true);
            this.isSelected = true;
        }
    }

    public void Death()
    {
        Destroy(this.gameObject);
        game.BotDeath();
        this.onDeath.Invoke();
    }
    
    public  void Goal()
    {
        Destroy(this.gameObject);
        game.BotEnd();
        this.onGoal.Invoke();
    }
}
