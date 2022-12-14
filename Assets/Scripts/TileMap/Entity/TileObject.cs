using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    [Header("Tile Rendering")]
    [SerializeField] private MeshRenderer meshRenderer;

    public Texture2D texture { get; protected set; }
    public TileMapObject tileMapObject { get; protected set; }
    public Vector2Int tileMapPos { get; protected set; }
    public Vector2 tileScale { get; protected set; } = Vector3.one;
    public bool isWalkable { get; protected set; }
    public bool isFlyable { get; protected set; }
    public bool isKill { get; protected set; }
    public bool isWin { get; protected set; }
    public bool isFire { get; protected set; }
    public bool isVoid { get; protected set; }
    public bool isGadgetAllowed { get; protected set; }
    public GadgetObject gadgetOnTile { get; set; }

    /// <summary>
    /// Instantiate a new TileObject
    /// </summary>
    /// <param name="prefab"></param>
    /// <param name="tileMap"></param>
    /// <param name="mapPos"></param>
    /// <returns></returns>
    public static TileObject InstantiateObject(GameObject prefab, TileMapObject tileMap, Vector2Int mapPos)
    {
        TileObject instance = GameObject.Instantiate(prefab, tileMap.transform).GetComponent<TileObject>();
        instance.tileMapObject = tileMap;
        instance.tileMapPos = mapPos;
        instance.transform.localPosition = new Vector3(instance.tileScale.x * (instance.tileMapPos.x - (tileMap.size.x) / 2), 0, instance.tileScale.y * (instance.tileMapPos.y - (tileMap.size.y) / 2));
        // instance.SetTexture(mapPos);
        instance.Setup();
        return instance;
    }

    /// <summary>
    /// Setup tile's specific variables
    /// </summary>
    protected virtual void Setup()
    {
        this.isWalkable = true;
        this.isFlyable = true;
        this.isKill = false;
        this.isWin = false;
        this.isFire = false;
        this.isVoid = false;
        this.isGadgetAllowed = true;
    }

    /// <summary>
    /// Setup specific variables after that the whole map has been instantiated.
    /// </summary>
    public virtual void AfterMapInit() {} 

    /// <summary>
    /// Triggered when robot land on tile
    /// </summary>
    /// <param name="robot"></param>
    public virtual void OnRobotLand(Robot robot) { }

    /// <summary>
    /// Change the texture of the tile
    /// </summary>
    /// <param name="mapPos"></param>
    protected void SetTexture(Vector2Int mapPos)
    {
        this.texture = new Texture2D(24, 24, TextureFormat.RGB24, true, true);
        this.texture.wrapMode = TextureWrapMode.Clamp;
        this.texture.filterMode = FilterMode.Bilinear;
        this.meshRenderer.material.SetTexture("_MainTex", texture);

        Color color = (mapPos.x + mapPos.y) % 2 == 0 ? new Color(0.4f, 0.4f, 0.4f) : Color.white;
        for (int x = 0; x < 24; x++)
            for (int y = 0; y < 24; y++)
                this.texture.SetPixel(x, y, color);
        this.texture.Apply();
    }

    public bool canReceiveGadget {
        get { return this.isGadgetAllowed && this.gadgetOnTile == null; }
    }
}
