using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotObjectHover : Robot
{
    public GadgetObject gadgetStored { get; private set; }

    private void Update()
    {
        this.Move();
    }

    public override void Action() {
        if (this.gadgetStored == null) this.PullGadget();
        else this.PushGadget();
    }

    public override string GetAbilityName()
    {
        return this.gadgetStored ? "Déposer" : "Prendre";
    }

    protected override bool CanGoOnTile(TileObject tile)
    {
        return tile.isFlyable;
    }

    /// <summary>
    /// Store gadget of the current map tile
    /// </summary>
    private void PullGadget()
    {
        GadgetObject gadget = this.tilemap.GetTileAt(this.mapcoord).gadgetOnTile;
        if (gadget != null && gadget.isGrabable && this.gadgetStored == null) {
            this.gadgetStored = gadget;
            this.gadgetStored.SetTileObject(null);
            this.gadgetStored.gameObject.SetActive(false);
            this.gadgetStored.transform.SetParent(this.transform);
        }
    }

    /// <summary>
    /// Deploy gadget stored in cache on the map
    /// </summary>
    private void PushGadget()
    {
        TileObject tile = this.tilemap.GetTileAt(this.mapcoord);
        if (tile != null && tile.canReceiveGadget && this.gadgetStored != null) {
            this.gadgetStored.SetTileObject(tile);
            this.gadgetStored.transform.SetParent(tile.transform);
            this.gadgetStored.transform.localPosition = Vector3.zero;
            this.gadgetStored.gameObject.SetActive(true);
            this.gadgetStored = null;
        }
    }
}
