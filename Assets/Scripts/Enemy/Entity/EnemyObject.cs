using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyObject : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;

    [Header("Enemy properties")]
    public Sprite visual;
    public float moveSpeed = 2f;
    public float attackSpeed = 7f;

    [Header("Enemy Sprites")]
    public Sprite forwardSprite;
    public Sprite backwarkSprite;
    public Sprite sideSprite;

    public enum Direction { None, Up, Down, Left, Right }
    public enum Strategy { None, Patrol }

    public Direction currentDirection { get; protected set; } = Direction.None;
    public Vector2Int mapPosition { get; protected set; }
    public TileMapObject tileMapObject { get; protected set; }
    public UnityEvent onDeath { get; protected set; } = new UnityEvent();
    public bool isAttacking { get; protected set; } = false;

    /// <summary>
    /// Crée un ennemi dans la scéne
    /// </summary>
    /// <param name="robot"></param>
    /// <param name="tile"></param>
    /// <returns></returns>
    public static EnemyObject InstantiateObject(GameObject prefab, TileObject tile)
    {
        EnemyObject instance = GameObject.Instantiate(prefab.gameObject, tile.transform.position, tile.transform.rotation).GetComponent<EnemyObject>();
        instance.mapPosition = tile.tileMapPos;
        instance.tileMapObject = tile.tileMapObject;
        return instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        Robot robot = other.GetComponent<Robot>();
        if (robot != null) {
            StartCoroutine(this.Attack(robot));
        }
    }

    /// <summary>
    /// Ajoute l'IA de l'ennemi
    /// </summary>
    /// <param name="strategy"></param>
    public void ApplyStrategy(LevelSerializableEnemySpawn strategy)
    {
        EnemyAIPatrol ia;
        switch (strategy.moveType)  {
            case "Patrol": ia = EnemyAIPatrol.AddBehavior(this, strategy); break;
            default: ia = null; break;
        }
        if (ia != null) StartCoroutine(ia.Execute());
    }

    /// <summary>
    /// Attack a robot and kill it
    /// </summary>
    /// <param name="robot"></param>
    /// <returns></returns>
    public IEnumerator Attack(Robot robot)
    {
        this.isAttacking = true;
        var startPos = this.transform.position;
        var endPos = robot.transform.position;
        float maxTime = (endPos - startPos).magnitude / this.attackSpeed;
        float time = 0f;
        while (time < maxTime) {
            time += Time.deltaTime;
            this.transform.position = Vector3.Lerp(startPos, endPos, Mathf.Min(1, time / maxTime));
            yield return new WaitForFixedUpdate();
        }
        robot.Death();
        time = 0f;
        while (time < maxTime) {
            time += Time.deltaTime;
            this.transform.position = Vector3.Lerp(endPos, startPos, Mathf.Min(1, time / maxTime));
            yield return new WaitForFixedUpdate();
        }
        this.isAttacking = false;
    }

    /// <summary>
    /// Move toward a direction
    /// </summary>
    /// <returns></returns>
    public IEnumerator Move()
    {
        Vector2Int offset = Vector2Int.zero;
        switch (this.currentDirection) {
            case Direction.Up: offset = Vector2Int.up; break;
            case Direction.Down: offset = Vector2Int.down; break;
            case Direction.Left: offset = Vector2Int.left; break;
            case Direction.Right: offset = Vector2Int.right; break;
        }
        if (offset != Vector2Int.zero) {
            TileObject targetTile = this.tileMapObject.GetTileAt(this.mapPosition + offset);
            var startPos = this.transform.position;
            var endPos = targetTile.transform.position;
            float maxTime = (endPos - startPos).magnitude / this.moveSpeed;
            float time = 0f;
            while (time < maxTime) {
                yield return new WaitWhile(() => this.isAttacking);
                time += Time.deltaTime;
                this.transform.position = Vector3.Lerp(startPos, endPos, Mathf.Min(1, time / maxTime));
                yield return new WaitForFixedUpdate();
            }
            this.mapPosition = targetTile.tileMapPos;
        }
        yield return null;
    }

    /// <summary>
    /// Change the direction of this enemy
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection(EnemyObject.Direction direction)
    {
        // this._animator.SetBool("onDirChange", this.currentDirection != direction);
        this.currentDirection = direction;
    }

    /// <summary>
    /// Triggered by animator to switch sprite when rotating robot
    /// </summary>
    public void ChangeSprite()
    {
        Sprite newSprite = this.forwardSprite;
        switch (this.currentDirection)
        {
            case Direction.Up: newSprite = this.backwarkSprite; break;
            case Direction.Left: newSprite = this.sideSprite; break;
            case Direction.Right: newSprite = this.sideSprite; break;
        }
        this._spriteRenderer.sprite = newSprite;
        this._spriteRenderer.flipX = this.currentDirection == Direction.Left;
        this._animator.SetBool("onDirChange", false);
    }
}