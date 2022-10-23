using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hovering Robot - Siel.
/// It flies hover tiles and can carry light gadgets
/// </summary>
public class RobotObjectHover : Robot
{
    public GadgetObject gadgetStored { get; private set; }

    void Update()
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

    // ===== Specifics of Hovering Robot

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

            // Addition to fire events based on gadget pressing tiles 
            ITileButtonPress presser = gadget as ITileButtonPress;
            if (presser != null) {
                ((ITileButtonPress)gadget).onPressStatusChange.Invoke(false);
            }

            this.onStatusChanged.Invoke();
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
            this.onStatusChanged.Invoke();
        }
    }
}
