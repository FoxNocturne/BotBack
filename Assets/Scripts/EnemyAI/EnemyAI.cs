using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class EnemyAI : MonoBehaviour
{
    protected Vector2 _movementVector;

    protected virtual void Update()
    {
        SendMessage("Move", _movementVector);
    }
}
