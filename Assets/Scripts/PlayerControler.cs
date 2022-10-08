using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : BotBackManager
{
    public Robot SelectedRobot;
    public Robot[] Robots;
    private Vector3 pos = Vector3.zero;
    public float CellSize = 0.2f;              
    public float speed = 1.0f; 

    private void Start()
    {
        SelectedRobot = Robots[0];
    }
    public void GoForward()
    {
        Robots[0].GetComponent<Robot>().GoUp( Vector3.forward);
    }
    public void GoBackward()
    {
        SelectedRobot.GoDown(pos + Vector3.back * CellSize);
    }
    public void GoLeft()
    {
       SelectedRobot.GoLeft(pos + Vector3.left * CellSize);
    }
    public void GoRight()
    {
        SelectedRobot.GoRight(pos + Vector3.right * CellSize);
    }

    void FixedUpdate()
    {
       // if ( SelectedRobot )
        //    SelectedRobot.position = Vector3.MoveTowards(SelectedRobot.position, pos, Time.deltaTime * speed);   
    }

    public void ChangeBot(InputAction.CallbackContext context)
    {
        if (context.performed && Robots.Length >= int.Parse(context.control.name) && Robots[int.Parse(context.control.name) - 1])
        {
            Debug.Log(context.control.name);
            //SelectedRobot = Robots[int.Parse(context.control.name) - 1];
            //pos = SelectedRobot.transform.position;
        }
    }

    public void BotAction()
    {
        if (SelectedRobot)
        {
            //SelectedRobot.GetComponent<Robot>().Action();
            Debug.Log("Action");
        }
    }
}
