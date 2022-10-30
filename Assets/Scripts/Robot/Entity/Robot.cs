using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Robot : BotBackManager
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;

    [Header("Robot properties")]
    public Sprite visual;
    public float robotSpeed = 2f;

    [Header("Robot Sprites")]
    public Sprite forwardSprite;
    public Sprite backwarkSprite;
    public Sprite sideSprite;

    public enum Stat { none, up, down, left, right }
    public Vector3 position { get; protected set; }
    public bool isWalking { get; protected set; }
    public Stat currentStatus { get; protected set; } = Stat.none;
    public float tileSize { get; protected set; }
    public bool isSelected { get; protected set; } = false;
    protected Vector2Int mapcoord;
    public TileMapObject tilemap { get; protected set; }
    public Rigidbody rb { get; set; }
    public UnityEvent onDeath { get; protected set; } = new UnityEvent();
    public UnityEvent onGoal { get; protected set; } = new UnityEvent();
    public UnityEvent onStatusChanged { get; protected set; } = new UnityEvent();
    public RobotMarkerObject markerObject { get; protected set; }

    void Awake()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.markerObject = this.GetComponentInChildren<RobotMarkerObject>();
    }

    /// <summary>
    /// Crée un robot dans la scéne
    /// </summary>
    /// <param name="robot"></param>
    /// <param name="tile"></param>
    /// <returns></returns>
    public static Robot InstantiateObject(GameObject prefab, TileObject tile)
    {
        Robot instance = GameObject.Instantiate(prefab.gameObject, tile.transform.position, tile.transform.rotation).GetComponent<Robot>();
        instance.position = tile.transform.position;
        instance.mapcoord = tile.tileMapPos;
        instance.tilemap = tile.tileMapObject;
        instance.markerObject = instance.GetComponentInChildren<RobotMarkerObject>();
        return instance;
    }

    public virtual void GoUp(float size)
    {
        if (this.currentStatus != Stat.up) {
            this.currentStatus = Stat.up;
            this.tileSize = size;
            this._animator.SetTrigger("onDirChange");
        }
    }

    public virtual void GoDown(float size)
    {
        if (this.currentStatus != Stat.down) {
            this.currentStatus = Stat.down;
            this.tileSize = size;
            this._animator.SetTrigger("onDirChange");
        }
    }

    public virtual void GoLeft(float size)
    {
        if (this.currentStatus != Stat.left) {
            this.currentStatus = Stat.left;
            this.tileSize = size;
            this._animator.SetTrigger("onDirChange");
        }
    }

    public virtual void GoRight(float size)
    {
        if (this.currentStatus != Stat.right) {
            this.currentStatus = Stat.right;
            this.tileSize = size;
            this._animator.SetTrigger("onDirChange");
        }
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
                    if (tilemap == null || this.CanGoOnTile(this.tilemap.GetTileAt(new Vector2Int(mapcoord.x, mapcoord.y + 1))))
                    {
                        mapcoord.y += 1;
                        position = position + (Vector3.forward * this.tileSize);
                    }
                    else
                    {
                        this.GoDown(this.tileSize);
                    }
                    break;
                case Stat.down:
                    if (tilemap == null || this.CanGoOnTile(this.tilemap.GetTileAt(new Vector2Int(mapcoord.x, mapcoord.y - 1))))
                    {
                        mapcoord.y -= 1;
                        position = position + (Vector3.back * this.tileSize);
                    }
                    else
                    {
                        this.GoUp(this.tileSize);
                    }
                    break;
                case Stat.left:
                    if (tilemap == null || this.CanGoOnTile(this.tilemap.GetTileAt(new Vector2Int(mapcoord.x - 1, mapcoord.y))))
                    {
                        mapcoord.x -= 1;
                        position = position + (Vector3.left * this.tileSize);
                    }
                    else
                    {
                        this.GoRight(this.tileSize);
                    }
                    break;
                case Stat.right:
                    if (tilemap == null || this.CanGoOnTile(this.tilemap.GetTileAt(new Vector2Int(mapcoord.x + 1, mapcoord.y))))
                    {
                        mapcoord.x += 1;
                        position = position + (Vector3.right * this.tileSize);
                    }
                    else
                    {
                        this.GoLeft(this.tileSize);
                    }
                    break;
            }
        }
        if (this.isWalking == true) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.position, Time.deltaTime * this.robotSpeed);
        }
        if (Vector3.Distance(this.transform.position, this.position) == 0) {
            this.isWalking = false;
            this.tilemap.GetTileAt(this.mapcoord).OnRobotLand(this);
            if (tilemap.checkKill(mapcoord) && !tilemap.checkVoid(mapcoord))
                Death();
        } else {
            this.isWalking = true;
        }
    }

    public abstract void Action();

    public abstract string GetAbilityName();

    public virtual void Select()
    {
        this.isSelected = !this.isSelected;
        this.markerObject.SetSelected(this.isSelected);
    }

    /// <summary>
    /// Triggered by animator to switch sprite when rotating robot
    /// </summary>
    public void ChangeSprite()
    {
        Sprite newSprite = this.forwardSprite;
        switch (this.currentStatus) {
            case Stat.up: newSprite = this.backwarkSprite; break;
            case Stat.left: newSprite = this.sideSprite; break;
            case Stat.right: newSprite = this.sideSprite; break;
        }
        this._spriteRenderer.sprite = newSprite;
        this._spriteRenderer.flipX = this.currentStatus == Stat.left;
        this._animator.SetBool("onDirChange", false);
    }

    public void Death()
    {
        this.onDeath.Invoke();
        this.onDeath.RemoveAllListeners();
        this.onGoal.RemoveAllListeners();
        this.onStatusChanged.RemoveAllListeners();
        Destroy(this.gameObject);
    }
    
    public void Goal()
    {
        this.onGoal.Invoke();
        Destroy(this.gameObject);
    }

    protected abstract bool CanGoOnTile(TileObject tile);
}
