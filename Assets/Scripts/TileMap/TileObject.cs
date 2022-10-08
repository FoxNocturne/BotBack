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
        instance.transform.position = new Vector3(instance.tileScale.x * instance.tileMapPos.x, 0, instance.tileScale.y * instance.tileMapPos.y);

        instance.SetTexture(mapPos);

        return instance;
    }

    private void SetTexture(Vector2Int mapPos)
    {
        this.texture = new Texture2D(24, 24, TextureFormat.RGB24, true, true);
        this.texture.wrapMode = TextureWrapMode.Clamp;
        this.texture.filterMode = FilterMode.Bilinear;
        this.meshRenderer.material.SetTexture("_MainTex", texture);

        Color color = (mapPos.x + mapPos.y) % 2 == 0 ? Color.black : Color.white;
        for (int x = 0; x < 24; x++)
            for (int y = 0; y < 24; y++)
                this.texture.SetPixel(x, y, color);
        this.texture.Apply();
    }
}
