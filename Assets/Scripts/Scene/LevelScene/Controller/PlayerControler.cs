using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerControler : BotBackManager
{
    public GameObject SelectedRobot = null;
    
    public List<Robot> _listRobot;
    public float CellSize = 0.2f;
     int botnb = 0;
    public int botpassed = 0;
    public ControlWrapperCanvas tool;
    private bool win = false;
    public bool hasStopped { get; private set; } = false;

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
            tool.Show(SelectedRobot.GetComponent<Robot>().visual);
        }
    }

    public void BotAdd()
    {
        botnb++;
    }

    public void BotAction()
    {
        if (!win && SelectedRobot != null)
        {
            SelectedRobot.GetComponent<Robot>().Action();
            Debug.Log("Action");
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
