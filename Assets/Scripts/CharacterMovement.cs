using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 3f;

    private CharacterController _characterController;
    private Vector2 _speed;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();    
    }

    private void Update()
    {
        _characterController.SimpleMove(new Vector3(_speed.x, 0, _speed.y));
    }

    void OnMove(InputValue value)
    {
        _speed = value.Get<Vector2>() * movementSpeed;
        Debug.Log($"{_speed}");
    }
}
