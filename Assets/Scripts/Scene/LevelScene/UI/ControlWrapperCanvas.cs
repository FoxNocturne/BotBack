using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWrapperCanvas : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Show()
    {
        this._animator.SetBool("isShown", true);
    }

    public void Hide()
    {
        this._animator.SetBool("isShown", false);
    }
}
