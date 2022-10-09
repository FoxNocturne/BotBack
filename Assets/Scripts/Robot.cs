using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Robot : BotBackManager
{
     public Vector3 position { set; get; }
     public bool isWalking { set; get; }
    public Vector2 mapcoord;
    public TileMapObject tilemap;
    public Sprite visual;

    public UnityEvent onDeath = new UnityEvent();
    public UnityEvent onGoal = new UnityEvent();

    public abstract void GoUp(float size);
    public abstract void GoLeft(float size);
    public abstract void GoRight(float size);
    public abstract void GoDown(float size);

    public abstract void Action();
    public abstract void Stop();
    public abstract void Select();

    public void Death()
    {
        this.onDeath.Invoke();
    }
    
    public  void Goal()
    {
        this.onGoal.Invoke();
    }
}
