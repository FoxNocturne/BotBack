using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlWrapperCanvas : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public Image robot;

    public void Show(Sprite toshow)
    {
        this._animator.SetBool("isShown", true);
        robot.sprite = toshow;
    }

    public void Hide()
    {
        this._animator.SetBool("isShown", false);
        robot.sprite = null;
    }
}
