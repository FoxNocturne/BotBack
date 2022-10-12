using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotteur : Robot
{
    private void Update()
    {
        this.Move();
    }

    public override void Action() { }

    protected override bool CanGoOnTile(TileObject tile)
    {
        return tile.isFlyable;
    }
}
