using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotteur : Robot
{
    public override void GoUp(Vector3 pos)
    {
        base.GoUp(pos);
        Debug.Log("Ok2");
        this.position = this.transform.position + pos;
        //this.transform.position = this.position;
    }
    public override void GoDown(Vector3 pos)
    {
        base.GoDown(pos);
        this.position = this.transform.position + pos;
        //this.transform.position = this.position;
    }
    public override void GoLeft(Vector3 pos)
    {
        base.GoLeft(pos);
        this.position = this.transform.position + pos;
        //this.transform.position = this.position;
    }
    public override void GoRight(Vector3 pos)
    {
        base.GoRight(pos);
        this.position = this.transform.position + pos;
        //this.transform.position = this.position;
    }



    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.position, Time.deltaTime);
    }
}