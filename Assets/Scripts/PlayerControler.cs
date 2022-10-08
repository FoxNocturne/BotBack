using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public Transform SelectedRobot = null;
    public GameObject[] Robots;
    Vector3 pos;
    public float CellSize = 0.2f;              
    public float speed = 1.0f; 

    public void GoForward()
    {
        if ( SelectedRobot )
        {
            SelectedRobot.GetComponent<Robot>().GoUp();
           // pos += Vector3.forward * CellSize;
        }
    }
    public void GoBackward()
    {
        if (SelectedRobot)
        {
            SelectedRobot.GetComponent<Robot>().GoDown();
           // pos += Vector3.back * CellSize;
        }
    }
    public void GoLeft()
    {
        if (SelectedRobot)
        {
            SelectedRobot.GetComponent<Robot>().GoLeft();
            //pos += Vector3.left * CellSize;
        }
    }
    public void GoRight()
    {
        if (SelectedRobot)
        {
            SelectedRobot.GetComponent<Robot>().GoRight();
            //pos += Vector3.right * CellSize;
        }
    }

    void FixedUpdate()
    {
        if ( SelectedRobot )
            SelectedRobot.position = Vector3.MoveTowards(SelectedRobot.position, pos, Time.deltaTime * speed);   
    }

    public void ChangeBot(  InputAction.CallbackContext context  )  
    {
        if ( context.performed &&  Robots.Length >= int.Parse(context.control.name) && Robots[ int.Parse(context.control.name) - 1] )
        {
            Debug.Log(context.control.name);
            SelectedRobot = Robots[int.Parse(context.control.name) - 1].transform;
            pos = SelectedRobot.position;
        }
    }

    public void BotAction()
    {
        if (SelectedRobot)
        {
            SelectedRobot.GetComponent<Robot>().Action();
            Debug.Log("Action");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
