using UnityEditor;
using UnityEngine;

public abstract class GadgetObject : MonoBehaviour
{
    public TileObject tileObject { get; protected set; }
    public bool isGrabable { get; protected set; }

    /// <summary>
    /// Instantiate a new gadget
    /// </summary>
    /// <param name="prefab">Prefab of the gadget to instantiate</param>
    /// <param name="tileObject">Parent tile object which will hold the new gadget</param>
    /// <returns></returns>
    public static GadgetObject InstantiateObject(GameObject prefab, TileObject tileObject)
    {
        GadgetObject instance = GameObject.Instantiate(prefab, tileObject.transform).GetComponent<GadgetObject>();
        instance.SetTileObject(tileObject);
        instance.tileObject = tileObject;
        tileObject.gadgetOnTile = instance;
        instance.Setup();
        return instance;
    }

    /// <summary>
    /// Assign the gadget objet to the given tile object
    /// </summary>
    /// <param name="tileObject"></param>
    public void SetTileObject(TileObject tileObject = null)
    {
        if (this.tileObject != null) {
            this.tileObject.gadgetOnTile = null;
        }
        this.tileObject = tileObject;
        if (tileObject != null) {
            tileObject.gadgetOnTile = this;
        }
    }

    /// <summary>
    /// Initialize this gadget values
    /// </summary>
    protected abstract void Setup();
}