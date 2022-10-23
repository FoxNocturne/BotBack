using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileObjectButton : TileObject
{
    [Header("Button Specifics")]
    [SerializeField] private LevelEventService.Channel _channel;

    public ITileButtonPress currentPresser { get; private set; }
    public bool isActivated { get; private set; }

    private UnityAction<bool> _toPressStatusChange;

    void Awake()
    {
        this.isActivated = false;
        this._toPressStatusChange = new UnityAction<bool>(isPressed => {
            if (!isPressed) { this.Deactivate(); }
        });
    }

    void OnTriggerEnter(Collider other)
    {
        ITileButtonPress presser = other.gameObject.GetComponent<ITileButtonPress>();
        if (presser != null && presser.CanPressButton() && !this.isActivated) {
            this.Activate(presser);
        }
    }

    void OnTriggerExit(Collider other)
    {
        ITileButtonPress presser = other.gameObject.GetComponent<ITileButtonPress>();
        if (presser != null && presser.CanPressButton() && this.isActivated) {
            this.Deactivate();
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
        this.isGadgetAllowed = true;
    }

    protected void Activate(ITileButtonPress presser)
    {
        this.currentPresser = presser;
        this.currentPresser.onPressStatusChange.AddListener(this._toPressStatusChange);
        this.isActivated = true;
        LevelEventService.instance.Activate(this._channel);
    }

    protected void Deactivate()
    {
        if (this.currentPresser != null) {
            this.currentPresser.onPressStatusChange.RemoveListener(this._toPressStatusChange);
        }
        this.currentPresser = null;
        this.isActivated = false;
        LevelEventService.instance.Deactivate(this._channel);
    }
}
