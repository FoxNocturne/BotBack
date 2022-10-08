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

    public void GoForward()
    {
        if (SelectedRobot != null)
        {
            SelectedRobot.GetComponent<IRobot>().GoUp(CellSize);
        }
    }
    public void GoBackward()
    {
        if (SelectedRobot != null)
        {
            SelectedRobot.GetComponent<IRobot>().GoDown(CellSize);
        }
    }
    public void GoLeft()
    {
        if (SelectedRobot != null)
        {
            SelectedRobot.GetComponent<IRobot>().GoLeft(CellSize);
        }
    }
    public void GoRight()
    {
        if (SelectedRobot != null)
        {
            SelectedRobot.GetComponent<IRobot>().GoRight(CellSize);
        }
    }

    void FixedUpdate()
    {
       // if ( SelectedRobot )
        //    SelectedRobot.position = Vector3.MoveTowards(SelectedRobot.position, pos, Time.deltaTime * speed);   
    }

    public void ChangeBot(InputAction.CallbackContext context)
    {
        if (context.performed && Robots.Length >= int.Parse(context.control.name) && Robots[int.Parse(context.control.name) - 1] != null)
        {
            Debug.Log(context.control.name);
            SelectedRobot = Robots[int.Parse(context.control.name) - 1];
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
        Debug.Log("You Win");
    }

    public void BotAction()
    {
        if (SelectedRobot != null)
        {
            SelectedRobot.GetComponent<IRobot>().Action();
            Debug.Log("Action");
        }
    }
}
