using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : BotBackManager
{
    public GameObject SelectedRobot = null;
    
    public GameObject[] Robots;
    public float CellSize = 0.2f;
    public int botnb = 3;
    public int botpassed = 0;
    private bool win = false;

    public void GoForward()
    {
        if (!win && SelectedRobot != null)
        {
            SelectedRobot.GetComponent<IRobot>().GoUp(CellSize);
        }
    }
    public void GoBackward()
    {
        if (!win && SelectedRobot != null)
        {
            SelectedRobot.GetComponent<IRobot>().GoDown(CellSize);
        }
    }
    public void GoLeft()
    {
        if (!win && SelectedRobot != null)
        {
            SelectedRobot.GetComponent<IRobot>().GoLeft(CellSize);
        }
    }
    public void GoRight()
    {
        if (!win && SelectedRobot != null)
        {
            SelectedRobot.GetComponent<IRobot>().GoRight(CellSize);
        }
    }

    public void Start()
    {
        GlobalTimer.Go(60.0f);
    }
    

    public void ChangeBot(InputAction.CallbackContext context)
    {
        if (!win && context.performed && Robots.Length >= int.Parse(context.control.name) && Robots[int.Parse(context.control.name) - 1] != null)
        {
            Debug.Log(context.control.name);
            if ( SelectedRobot != null )
                SelectedRobot.GetComponent<IRobot>().Select();
            SelectedRobot = Robots[int.Parse(context.control.name) - 1];
            SelectedRobot.GetComponent<IRobot>().Select();
        }
    }

    public void BotDeath()
    {
        botnb--;
    }

    public void BotEnd()
    {
        botpassed+=1;
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
            SelectedRobot.GetComponent<IRobot>().Action();
            Debug.Log("Action");
        }
    }

    public void BotStop()
    {
        if ( !win && SelectedRobot != null )
        {
            SelectedRobot.GetComponent<IRobot>().Stop();
        }
    }
}
