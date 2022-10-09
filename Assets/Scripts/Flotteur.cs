using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flotteur : Robot
{
    public override void Action() { }

    private void Update()
    {
        this.Move();
        if (Vector3.Distance(this.transform.position, this.position) == 0)
        {
            this.isWalking = false;
            if (tilemap.checkKill(mapcoord) && !tilemap.checkVoid(mapcoord))
                Death();
            if (tilemap.checkWin(mapcoord))
                Goal();
        }
        else
        {
            this.isWalking = true;
        }


    }

}
