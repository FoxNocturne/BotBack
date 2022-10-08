using System;
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
    private bool _movementIsEnabled;

    public IEnumerator PauseMovementTemporarily()
    {
        _movementIsEnabled = false;
        yield return new WaitForSeconds(1f);
        _movementIsEnabled = true;
    }

    private void Start()
    {
        _movementIsEnabled = true;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_movementIsEnabled) _characterController.SimpleMove(new Vector3(_speed.x, 0, _speed.y));
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
