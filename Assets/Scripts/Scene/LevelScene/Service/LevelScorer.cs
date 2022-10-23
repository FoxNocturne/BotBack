using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelScorer
{
    public UnityEvent<int> onScoreChanged { get; private set; } = new UnityEvent<int>();
    public int currentScore { get; private set; }

    public LevelScorer()
    {
        this.currentScore = 0;
    }

    public void IncreaseScore(int points)
    {
        this.currentScore += points;
        this.onScoreChanged.Invoke(this.currentScore);
    }
}