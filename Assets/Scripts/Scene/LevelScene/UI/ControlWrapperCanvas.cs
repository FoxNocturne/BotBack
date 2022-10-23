using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ControlWrapperCanvas : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _robotImage;
    [SerializeField] private Text _robotAbilityText;

    private Robot _currentRobot;
    private UnityAction _robotStatusChangeAction;

    void Awake()
    {
        this._currentRobot = null;
        this._robotStatusChangeAction = this.PrintAbilityText();    
    }

    /// <summary>
    /// Print selected robot data on screen
    /// </summary>
    /// <param name="robot"></param>
    public void Show(Robot robot)
    {
        if (this._currentRobot != null) {
            this._currentRobot.onStatusChanged.RemoveListener(this._robotStatusChangeAction);
        }

        this._currentRobot = robot;
        this._currentRobot.onStatusChanged.AddListener(this._robotStatusChangeAction);
        this._currentRobot.onDeath.AddListener(this.Hide);
        this._robotImage.sprite = robot.visual;
        this._robotAbilityText.text = robot.GetAbilityName() + "()";

        this._animator.SetBool("isShown", true);
    }

    /// <summary>
    /// Hide selected robot data from screen
    /// </summary>
    public void Hide()
    {
        this._currentRobot = null;
        this._animator.SetBool("isShown", false);
        this._robotImage.sprite = null;
        this._robotAbilityText.text = "Agir()";
    }

    private UnityAction PrintAbilityText() {
        return new UnityAction(() => {
            this._robotAbilityText.text = this._currentRobot.GetAbilityName() + "()";
        });
    }
}
