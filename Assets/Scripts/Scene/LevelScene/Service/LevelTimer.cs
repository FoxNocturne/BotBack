using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelTimer
{
    public UnityEvent<float> onTimeChanged { get; private set; } = new UnityEvent<float>();
    public UnityEvent onTimerEnd { get; private set; } = new UnityEvent();
    public float remainingTime { get; private set; } = 0;
    public bool isRunning { get; private set; } = false;

    public LevelTimer(float maxTime)
    {
        this.remainingTime = maxTime;
    }

    public void SetRemainingTime(float time)
    {
        this.remainingTime = time;
    }

    public void Pause()
    {
        this.isRunning = false;
    }

    public IEnumerator RunTimer()
    {
        this.isRunning = true;
        while (this.isRunning && this.remainingTime > 0) {
            this.remainingTime -= Mathf.Min(this.remainingTime, Time.deltaTime);
            this.onTimeChanged.Invoke(this.remainingTime);
            yield return new WaitForEndOfFrame();
        }
        this.isRunning = false;
        if (this.remainingTime == 0) { this.onTimerEnd.Invoke(); }
    }
}