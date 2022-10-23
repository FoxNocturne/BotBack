using System.Collections;
using UnityEngine;

public class TileObjectDoor : TileObject
{
    [Header("Door Specifics")]
    [SerializeField] private Animator _animator;
    [SerializeField] private LevelEventService.Channel _channel;

    /// <summary>
    /// Setup tile's specific variables
    /// </summary>
    protected override void Setup()
    {
        this.isWalkable = false;
        this.isFlyable = false;
        this.isKill = false;
        this.isWin = false;
        this.isFire = false;
        this.isVoid = true;

        // Listen to event channel to manage door opening/closing
        LevelEventService.instance.onStatusChange.AddListener((channel, isActivated) => {
            if (channel == this._channel) {
                if (isActivated > 0) { this.Open(); } else { this.Close(); }
            }
        });
    }

    protected void Open()
    {
        this.isWalkable = true;
        this.isFlyable = true;
        this._animator.SetBool("isOpened", true);
    }

    protected void Close()
    {
        this.isWalkable = false;
        this.isFlyable = false;
        this._animator.SetBool("isOpened", false);
    }
}