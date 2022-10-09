using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : BotBackManager
{
    private GameObject SelectedRobot = null;
    
    public List<Robot> _listRobot;
    public float CellSize = 0.2f;
    public int botnb = 3;
    public int botpassed = 0;
    public ControlWrapperCanvas tool;
    private bool win = false;

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

    public void Start()
    {
        GlobalTimer.Go(60.0f);
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

    public void BotDeath()
    {
        botnb--;
        SelectedRobot.GetComponent<Robot>().Death();
    }

    public void BotEnd()
    {
        botpassed+=1;
        SelectedRobot.GetComponent<Robot>().Goal();
        Debug.Log("l:" + botpassed.ToString() + "/" + botnb);
        if (botpassed == botnb)
            LevelWin();
    }

    public void LevelWin()
    {
        win = true;
        Debug.Log("You Win");
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
        }
    }

    public void SetListRobot(List<Robot> listRobot) {
        this._listRobot = listRobot;
    }
}
