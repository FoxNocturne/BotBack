using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotteur : BotBackManager ,IRobot
{
    public enum Stat
    {
        up,
        down,
        left,
        right,
        none
    }

    public Stat stat;
    private float size;
    public Vector3 position { set; get; }
    public bool isWalking { set; get; }
    public void GoUp(float size)
    {
        stat = Stat.up;
        this.size = size;
    }
    public void GoDown(float size)
    {
        stat = Stat.down;
        this.size = size;
    }
    public void GoLeft(float size)
    {
        stat = Stat.left;
        this.size = size;
    }
    public void GoRight(float size)
    {
        stat = Stat.right;
        this.size = size;
    }

    public void Action() { }
    public void Stop() { stat = Stat.none; }

    void Start()
    {
        position = transform.position;
    }

    private void Update()
    {
        if (this.isWalking == false)
        {
            switch (this.stat)
            {
                case Stat.up:
                    position = position + (Vector3.forward * size);
                    break;
                case Stat.down:
                    position = position + (Vector3.back * size);
                    break;
                case Stat.left:
                    position = position + (Vector3.left * size);
                    break;
                case Stat.right:
                    position = position + (Vector3.right * size);
                    break;
            }
        }
        if (this.isWalking == true) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.position, Time.deltaTime);
        }
        if(Vector3.Distance(this.transform.position, this.position) == 0)
        {
            this.isWalking = false;
        }
        else
        {
            this.isWalking = true;
        }
        
    }

   
}
