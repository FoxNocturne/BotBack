using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Timer 
{
    private float timer;
    private float end;

    public void Go( float duration )
    {
        timer = Time.time;
        end = Time.time + duration;
    }

    public float GetTimer()
    {
        return (Time.time - timer);
    }

    public bool TimerFinish()
    {
        return (GetTimer() > end ? true : false );
    }
}
