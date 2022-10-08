using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRobot
{
     Vector3 position { set; get; }
     bool isWalking { set; get; }

    void GoUp(float size);
    void GoLeft(float size);
    void GoRight(float size);
    void GoDown(float size);

    void Action();
    void Stop();
}
