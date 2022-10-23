using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : BotBackManager
{
    [Header("UI Components")]
    [SerializeField] private ControlWrapperCanvas _guiRobotControl;

    [Header("Controller parameters")]
    [SerializeField] private float _baseInputCooldown = 0.2f;

    public float CellSize = 1f;
    public bool hasStopped { get; private set; } = false;

    private Robot _selectedRobot;
    private List<Robot> _listRobot;
    private Dictionary<string, float> _currentActionCooldown = new Dictionary<string, float>();

    void Update()
    {
        this.UpdateInputCooldown();
    }

    // ===== Player Inputs

    public void GoForward()
    {
        if (this._selectedRobot != null) {
            this._selectedRobot.GoUp(CellSize);
        }
    }

    public void GoBackward()
    {
        if (this._selectedRobot != null) {
            this._selectedRobot.GoDown(CellSize);
        }
    }

    public void GoLeft()
    {
        if (this._selectedRobot != null) {
            this._selectedRobot.GoLeft(CellSize);
        }
    }

    public void GoRight()
    {
        if (this._selectedRobot != null) {
            this._selectedRobot.GoRight(CellSize);
        }
    }

    /// <summary>
    /// Invoked by PlayerInput system.
    /// Change selected robot.
    /// </summary>
    /// <param name="context"></param>
    public void ChangeBot(InputAction.CallbackContext context)
    {
        int controlId = int.Parse(context.control.name);
        string inputKey = "action" + controlId.ToString();
        if (context.performed
            && this._listRobot.Count >= controlId
            && this._listRobot[controlId - 1] != null
            && !this.IsInputUnderCooldown(inputKey)
        ) {
            if (this._selectedRobot != null) { this._selectedRobot.Select(); }
            this._selectedRobot = this._listRobot[controlId - 1];
            this._selectedRobot.Select();
            this._guiRobotControl.Show(this._selectedRobot);
            this.StartInputCooldown(inputKey);
        }
    }

    /// <summary>
    /// Invoked by PlayerInput system.
    /// Fire selected robot's special action
    /// </summary>
    public void TriggerRobotAction(InputAction.CallbackContext context)
    {
        string inputKey = "action";
        if (this._selectedRobot != null && context.ReadValue<float>() > 0 && !this.IsInputUnderCooldown(inputKey)) {
            this._selectedRobot.Action();
            this.StartInputCooldown(inputKey);
        }
    }

    /// <summary>
    /// Invoked by PlayerInput system. Stop selected robot's walk.
    /// </summary>
    public void TriggerRobotStop(InputAction.CallbackContext context)
    {
        string inputKey = "stop";
        if (this._selectedRobot != null && context.ReadValue<float>() > 0 && !this.IsInputUnderCooldown(inputKey)) {
            this._selectedRobot.Stop();
            this.hasStopped = true;
            this.StartInputCooldown(inputKey);
        }
    }

    // ===== Input cooldown methods

    protected void StartInputCooldown(string key)
    {
        if (!this._currentActionCooldown.ContainsKey(key)) { this._currentActionCooldown.Add(key, this._baseInputCooldown); }
        else { this._currentActionCooldown[key] = this._baseInputCooldown; }
    }

    protected void UpdateInputCooldown()
    {
        var listKey = this._currentActionCooldown.Keys.ToList();
        foreach (string key in listKey) {
            this._currentActionCooldown[key] -= Time.deltaTime;
            if (this._currentActionCooldown[key] <= 0) { this._currentActionCooldown.Remove(key); }
        }
    }

    protected bool IsInputUnderCooldown(string key)
    {
        return this._currentActionCooldown.ContainsKey(key);
    }

    // ===== Getters / Setters
    public void SetListRobot(List<Robot> listRobot)
    {
        this._listRobot = listRobot;
    }

}
