using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Robot : BotBackManager
{
    [Header("Robot properties")]
    public Sprite visual;
    public float robotSpeed = 2f;
    public GameObject selectT;
    public GameObject selectF;

    public enum Stat { none, up, down, left, right }
    public Vector3 position { get; protected set; }
    public bool isWalking { get; protected set; }
    public Stat currentStatus { get; protected set; } = Stat.none;
    public float tileSize { get; protected set; }
    public bool isSelected { get; protected set; } = false;
    protected Vector2Int mapcoord;
    public TileMapObject tilemap { get; protected set; }
    public PlayerControler game { get; protected set; }
    public Rigidbody rb { get; set; }
    public UnityEvent onDeath { get; protected set; } = new UnityEvent();
    public UnityEvent onGoal { get; protected set; } = new UnityEvent();

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

    public virtual void Move()
    {
        if (this.isWalking == false) {
            switch (this.currentStatus) {
                case Stat.up:
                    if (tilemap == null || tilemap.checkgo(new Vector2Int(mapcoord.x, mapcoord.y + 1)))
                    {
                        mapcoord.y += 1;
                        position = position + (Vector3.forward * this.tileSize);
                    }
                    else
                    {
                        this.currentStatus = Stat.down;
                    }
                    break;
                case Stat.down:
                    if (tilemap == null || tilemap.checkgo(new Vector2Int(mapcoord.x, mapcoord.y - 1)))
                    {
                        mapcoord.y -= 1;
                        position = position + (Vector3.back * this.tileSize);
                    }
                    else
                    {
                        this.currentStatus = Stat.up;
                    }
                    break;
                case Stat.left:
                    if (tilemap == null || tilemap.checkgo(new Vector2Int(mapcoord.x - 1, mapcoord.y)))
                    {
                        mapcoord.x -= 1;
                        position = position + (Vector3.left * this.tileSize);
                    }
                    else
                    {
                        this.currentStatus = Stat.right;
                    }
                    break;
                case Stat.right:
                    if (tilemap == null || tilemap.checkgo(new Vector2Int(mapcoord.x + 1, mapcoord.y)))
                    {
                        mapcoord.x += 1;
                        position = position + (Vector3.right * this.tileSize);
                    }
                    else
                    {
                        this.currentStatus = Stat.left;
                    }
                    break;
            }
        }
        if (this.isWalking == true) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.position, Time.deltaTime * this.robotSpeed);
        }

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
