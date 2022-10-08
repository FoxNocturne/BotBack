using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : BotBackManager
{
    private void LateUpdate()
    {
        this.transform.eulerAngles = this.cam.transform.eulerAngles;
    }

    public void GoUp() { }
    public void GoDown() { }
    public void GoLeft() { }
    public void GoRight() { }
    public void Action() { }
}
