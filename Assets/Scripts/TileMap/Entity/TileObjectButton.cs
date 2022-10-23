using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObjectButton : TileObject
{
    [Header("Button Specifics")]
    [SerializeField] private LevelEventService.Channel _channel;

    public bool isActivated { get; private set; } = false;

    private void OnTriggerEnter(Collider other)
    {
        Robot robot = other.gameObject.GetComponent<Robot>();
        if (robot != null && robot.canPressButton && !this.isActivated) {
            this.isActivated = true;
            LevelEventService.instance.Activate(this._channel);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Robot robot = other.gameObject.GetComponent<Robot>();
        if (robot != null && robot.canPressButton && this.isActivated) {
            this.isActivated = false;
            LevelEventService.instance.Deactivate(this._channel);
        }
    }

    /// <summary>
    /// Setup tile's specific variables
    /// </summary>
    protected override void Setup()
    {
        this.isWalkable = true;
        this.isFlyable = true;
        this.isKill = false;
        this.isWin = false;
        this.isFire = false;
        this.isVoid = false;
    }

}
