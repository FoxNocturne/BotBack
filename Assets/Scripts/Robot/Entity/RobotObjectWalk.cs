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

    public override void Action() { }

    public override string GetAbilityName()
    {
        return "Agir";
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
