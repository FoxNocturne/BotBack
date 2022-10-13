using System.Collections;
using UnityEngine;

public class LevelScoreComputer
{
    public int baseScore { get; set; } = 0;
    public float timeMax { get; set; } = 0;
    public float timeRemaining { get; set; } = 0;
    public int nbRobot { get; set; } = 0;
    public int nbRobotSaved { get; set; } = 0;
    public bool hasStopped { get; set; } = true;

    public int timeScore { get { return Mathf.RoundToInt(500 * this.timeRemaining / this.timeMax) * 10; } }
    public int saveScore { get { return Mathf.RoundToInt(500 * this.nbRobotSaved / (float)this.nbRobot) * 10; } }
    public int noStopScore { get { return (!this.hasStopped ? 5000 : 0); } }
    public int totalScore { get { return this.baseScore + this.timeScore + this.saveScore + this.noStopScore; } }
}