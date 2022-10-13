using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Timer 
{
    private float timer;
    private float end;
    private float duration;

    public void Go( float duration )
    {
        timer = Time.time;
        end = Time.time + duration;
        this.duration = duration;
    }

    public float GetTimer()
    {
        return (Time.time - timer);
    }

    public int GetTimerPc()
    {
        return (Mathf.FloorToInt((180f * GetTimer()) / duration));
    }

    public int GetTimerPcInv()
    {
        return ( 180 - GetTimerPc() );
    }

    public bool TimerFinish()
    {
        return (GetTimer() > end ? true : false );
    }
}
