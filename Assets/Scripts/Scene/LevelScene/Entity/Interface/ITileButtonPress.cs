using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public interface ITileButtonPress
{
    public UnityEvent<bool> onPressStatusChange { get; }

    public bool CanPressButton();
}