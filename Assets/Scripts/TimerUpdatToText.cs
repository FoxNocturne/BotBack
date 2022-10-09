using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUpdatToText : BotBackManager
{
    private BatterySlider sl;  
    // Update is called once per frame
    void Update()
    {
        sl.SetValue(GlobalTimer.GetTimerPcInv());
    }

    void Start()
    {
        sl = this.GetComponent<BatterySlider>();
        sl.SetMaxValue(100f);
    }
}
