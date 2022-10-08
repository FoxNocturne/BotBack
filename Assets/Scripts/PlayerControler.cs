using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : BotBackManager
{
    public Flotteur SelectedRobot;

    private Vector3 pos = Vector3.zero;
    public float CellSize = 0.2f;              
    public float speed = 1.0f;
    public enum Stat
    {
        up,
        down,
        left,
        right,
        none
    }

    public Stat stat;

    private void Start()
    {
    }

    public void GoForward()
    {
        this.stat = Stat.up;
    }
    public void GoBackward()
    {
        this.stat = Stat.down;
    }
    public void GoLeft()
    {
        this.stat = Stat.left;
    }
    public void GoRight()
    {
        this.stat = Stat.right;
    }

    private void Update()
    {
            switch(this.stat)
            {
                case Stat.up:
                    SelectedRobot.GoUp(pos + Vector3.back * CellSize);
                    break;
                case Stat.down:
                    SelectedRobot.GoDown(pos + Vector3.forward * CellSize);
                    break;
                case Stat.left:
                    SelectedRobot.GoLeft(pos + Vector3.left * CellSize);
                    break;
                case Stat.right:
                    SelectedRobot.GoRight(pos + Vector3.left * CellSize);
                    break;
            }
    }

    void FixedUpdate()
    {
       // if ( SelectedRobot )
        //    SelectedRobot.position = Vector3.MoveTowards(SelectedRobot.position, pos, Time.deltaTime * speed);   
    }

    public void ChangeBot(InputAction.CallbackContext context)
    {
        //if (context.performed && Robots.Length >= int.Parse(context.control.name) && Robots[int.Parse(context.control.name) - 1])
        //{
        //    Debug.Log(context.control.name);
        //    //SelectedRobot = Robots[int.Parse(context.control.name) - 1];
        //    //pos = SelectedRobot.transform.position;
        //}
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
