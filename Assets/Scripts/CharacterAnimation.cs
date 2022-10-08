using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    private float _vertical;
    private float _horizontal;

    private void Awake()
    {
        Assert.IsNotNull(animator);    
    }

    private void Update()
    {
        animator.SetFloat("Vertical", _vertical);
        animator.SetFloat("Horizontal", _horizontal);
    }

    void OnMove(InputValue value)
    {
        Move(value.Get<Vector2>());
    }

    private void Move(Vector2 movementVector)
    {
        _vertical = (Mathf.Abs(movementVector.y) > Mathf.Abs(movementVector.x)) ? movementVector.y : 0;
        _horizontal = (Mathf.Abs(movementVector.x) > Mathf.Abs(movementVector.y)) ? movementVector.x : 0;
    }
}
