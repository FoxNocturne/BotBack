using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : Robot
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
    public GameObject selectT;
    public GameObject selectF; 
    public Transform pointShoot;
    public LineRenderer lineRenderer;
    private bool selected = false;
    private float size;
    public override void GoUp(float size)
    {
        stat = Stat.up;
        this.size = size;
    }
    public override void GoDown(float size)
    {
        stat = Stat.down;
        this.size = size;
    }
    public override void GoLeft(float size)
    {
        stat = Stat.left;
        this.size = size;
    }
    public override void GoRight(float size)
    {
        stat = Stat.right;
        this.size = size;
    }

    public override void Action() { }
    public override void Stop() { stat = Stat.none; }
    public override void Select()
    {
        if ( selected )
        {
            selectF.SetActive(true);
            selectT.SetActive(false);
            selected = false;
        }
        else
        {
            selectF.SetActive(false);
            selectT.SetActive(true);
            selected = true;
        }
    }

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
        if (this.isWalking == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.position, Time.deltaTime);
        }
        if (Vector3.Distance(this.transform.position, this.position) == 0)
        {
            this.isWalking = false;
        }
        else
        {
            this.isWalking = true;
        }

        lineRenderer.SetPosition(0, this.transform.position);
        lineRenderer.SetPosition(1, this.pointShoot.position);

    }
    

}
