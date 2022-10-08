using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : BotBackManager
{
    private void LateUpdate()
    {
        this.transform.eulerAngles = this.cam.transform.eulerAngles;
    }
}
