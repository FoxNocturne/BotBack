using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GadgetObjectCrate : GadgetObject, ITileButtonPress
{
    public UnityEvent<bool> onPressStatusChange { get; } = new UnityEvent<bool>();

    protected override void Setup()
    {
        this.isGrabable = true;
    }

    public bool CanPressButton()
    {
        return true;
    }
}
