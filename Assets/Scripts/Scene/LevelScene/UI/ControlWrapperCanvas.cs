using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlWrapperCanvas : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _robotImage;
    [SerializeField] private Text _robotAbilityText;

    public void Show(Robot robot)
    {
        this._animator.SetBool("isShown", true);
        this._robotImage.sprite = robot.visual;
        this._robotAbilityText.text = robot.GetAbilityName() + "()";
    }

    public void Hide()
    {
        this._animator.SetBool("isShown", false);
        this._robotImage.sprite = null;
        this._robotAbilityText.text = "Agir()";
    }
}
