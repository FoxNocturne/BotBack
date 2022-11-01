using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Walking Robot - Flair.
/// It walks on the ground and interact with gadgets on the floor (like buttons for example)
/// </summary>
public class RobotObjectWalk : Robot, ITileButtonPress
{
    public UnityEvent<bool> onPressStatusChange { get; } = new UnityEvent<bool>();

    private void Update()
    {
        this.Move();
    }

    public override void Action() {
        TileObjectPortal drillableTile = this.tilemap.GetTileAt(this.mapcoord).GetComponent<TileObjectPortal>();
        if (drillableTile != null && drillableTile.IsDrillable()) {
            this.Stop();
            this.position = drillableTile.linkedPortal.transform.position;
            this.mapcoord = drillableTile.linkedPortal.tileMapPos;
            this.transform.position = drillableTile.linkedPortal.transform.position;
            drillableTile.linkedPortal.OnRobotLand(this);
        }
    }

    public override string GetAbilityName()
    {
        return "Creuser";
    }

    protected override bool CanGoOnTile(TileObject tile)
    {
        return tile.isWalkable;
    }

    public bool CanPressButton()
    {
        return true;
    }
}
