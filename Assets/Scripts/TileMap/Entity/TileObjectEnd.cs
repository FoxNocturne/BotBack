using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObjectEnd : TileObject 
{
   // public PlayerControler game;
    /// <summary>
    /// Setup tile's specific variables
    /// </summary>
    protected override void Setup()
    {
        this.isWalkable = true;
        this.isKill = false;
        this.isWin = true;
    }

    //private void OnTriggerEnter(Collider other)
   // {
 
   //     Destroy(other.transform.gameObject);
     //   game.BotEnd();
  //  }
}
