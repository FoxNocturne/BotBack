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
    private Vector2 _movementVector;

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
        Move(value.Get<Vector2>());
    }

    void Move(Vector2 movementVector)
    {
        _movementVector = movementVector;
        _speed = _movementVector * movementSpeed;
    }
}
