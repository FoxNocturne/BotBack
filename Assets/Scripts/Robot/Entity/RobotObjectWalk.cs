using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotObjectWalk : Robot
{
    private void Update()
    {
        this.Move();
    }

    public override void Action() { }

    public override string GetAbilityName()
    {
        return "Agir";
    }

    protected override bool CanGoOnTile(TileObject tile)
    {
        return tile.isWalkable;
    }
}
