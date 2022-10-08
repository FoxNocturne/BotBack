using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUpdatToText : BotBackManager
{
    private Slider sl;  
    // Update is called once per frame
    void Update()
    {
        sl.value = GlobalTimer.GetTimerPcInv();
    }

    void Start()
    {
        sl = this.GetComponent<Slider>();
    }
}
