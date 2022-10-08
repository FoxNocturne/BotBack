using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : BotBackManager
{
    public GameObject SelectedRobot = null;

    [SerializeField]
    public GameObject[] Robots;
    public float CellSize = 0.2f;

    public void GoForward()
    {
        SelectedRobot.GetComponent<IRobot>().GoUp(CellSize);
    }
    public void GoBackward()
    {
        SelectedRobot.GetComponent<IRobot>().GoDown(CellSize);
    }
    public void GoLeft()
    {
        SelectedRobot.GetComponent<IRobot>().GoLeft(CellSize);
    }
    public void GoRight()
    {
        SelectedRobot.GetComponent<IRobot>().GoRight(CellSize);
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



    public void BotAction()
    {
        if (SelectedRobot != null)
        {
            SelectedRobot.GetComponent<IRobot>().Action();
            Debug.Log("Action");
        }
    }
}
