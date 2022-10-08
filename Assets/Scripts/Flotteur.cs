using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotteur : Robot
{
    public override void GoUp(Vector3 pos)
    {
        base.GoUp(pos);
        Debug.Log("Ok2");
        if (this.isWalking == false)
        {
            this.position = this.transform.position + pos;
        }
        //this.transform.position = this.position;
    }
    public override void GoDown(Vector3 pos)
    {
        base.GoDown(pos);
        if (this.isWalking == false)
        {
            this.position = this.transform.position + pos;
        }
        //this.transform.position = this.position;
    }
    public override void GoLeft(Vector3 pos)
    {
        base.GoLeft(pos);
        if (this.isWalking == false)
        {
            this.position = this.transform.position + pos;
        }
        //this.transform.position = this.position;
    }
    public override void GoRight(Vector3 pos)
    {
        base.GoRight(pos);
        if (this.isWalking == false)
        {
            this.position = this.transform.position + pos;
        }
        //this.transform.position = this.position;
    }



    private void Update()
    {
        if(this.isWalking == true) {
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
