using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControler : BotBackManager
{
    
    public float CellSize = 0.2f;
    [SerializeField] private ControlWrapperCanvas _guiRobotControl;
    private bool win = false;
    public bool hasStopped { get; private set; } = false;

    private GameObject SelectedRobot = null;
    private List<Robot> _listRobot;

    public void GoForward()
    {
        if (!win && SelectedRobot != null)
        {
            SelectedRobot.GetComponent<Robot>().GoUp(CellSize);
        }
    }

    public void GoBackward()
    {
        if (!win && SelectedRobot != null)
        {
            SelectedRobot.GetComponent<Robot>().GoDown(CellSize);
        }
    }

    public void GoLeft()
    {
        if (!win && SelectedRobot != null)
        {
            SelectedRobot.GetComponent<Robot>().GoLeft(CellSize);
        }
    }

    public void GoRight()
    {
        if (!win && SelectedRobot != null)
        {
            SelectedRobot.GetComponent<Robot>().GoRight(CellSize);
        }
    }

    public void ChangeBot(InputAction.CallbackContext context)
    {
        if (!win && context.performed
            && this._listRobot.Count >= int.Parse(context.control.name)
            && this._listRobot[int.Parse(context.control.name) - 1] != null
        ) {
            if (SelectedRobot != null) { SelectedRobot.GetComponent<Robot>().Select(); }
            SelectedRobot = this._listRobot[int.Parse(context.control.name) - 1].gameObject;
            SelectedRobot.GetComponent<Robot>().Select();
            this._guiRobotControl.Show(SelectedRobot.GetComponent<Robot>());
        }
    }

    public void BotAction()
    {
        if (!win && SelectedRobot != null)
        {
            SelectedRobot.GetComponent<Robot>().Action();
        }
    }

    public void BotStop()
    {
        if ( !win && SelectedRobot != null )
        {
            SelectedRobot.GetComponent<Robot>().Stop();
            this.hasStopped = true;
        }
    }

    public void SetListRobot(List<Robot> listRobot) {
        this._listRobot = listRobot;
    }
}
