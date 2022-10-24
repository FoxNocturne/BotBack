using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelScorer
{
    public UnityEvent<int> onScoreChanged { get; private set; } = new UnityEvent<int>();
    public UnityEvent<int, Vector3> onScoreChangePrinted { get; private set; } = new UnityEvent<int, Vector3>();
    public int currentScore { get; private set; }

    public LevelScorer()
    {
        this.currentScore = 0;
    }

    public void IncreaseScore(int points)
    {
        this.currentScore += points;
        this.onScoreChanged.Invoke(points);
    }

    public void IncreaseScorePrinted(int points, Vector3 worldPosition)
    {
        this.IncreaseScore(points);
        this.onScoreChangePrinted.Invoke(points, worldPosition);
    }
}