using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUpdatToText : BotBackManager
{
    private Text txt;  
    // Update is called once per frame
    void Update()
    {
        txt.text = Mathf.Floor(GlobalTimer.GetTimer()).ToString();
    }

    void Start()
    {
        txt = this.GetComponent<Text>();
    }
}
