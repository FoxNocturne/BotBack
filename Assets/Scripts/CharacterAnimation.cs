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
        var vector = value.Get<Vector2>();
        _vertical = (Mathf.Abs(vector.y) > Mathf.Abs(vector.x)) ? vector.y : 0;
        _horizontal = (Mathf.Abs(vector.x) > Mathf.Abs(vector.y)) ? vector.x : 0;
    }
}
