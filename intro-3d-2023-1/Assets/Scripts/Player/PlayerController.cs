using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float _moveSpeed = 2.0f;
    [SerializeField] private float _rotationSpeed = 15.0f;
    [SerializeField] private float _gravity = -15;

    [Header("Animator")]
    [SerializeField] private Transform _body;

    private float _verticalVelocity;
    
    private CharacterController _controller;
    private PlayerInput _input;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();
        LookAt();

    }

    private void Move()
    {
        float targetSpeed = _moveSpeed;
        if (_input.Move == Vector2.zero)
        {
            targetSpeed = 0.0f;
        }
 
        Vector3 targetMoveDirection = new Vector3(_input.Move.x, 0.0f, _input.Move.y).normalized;

        _verticalVelocity += _gravity * Time.deltaTime;
        
        _controller.Move((targetMoveDirection * targetSpeed * Time.deltaTime) + 
                         Vector3.up * _verticalVelocity * Time.deltaTime);
    }

    private void LookAt()
    {
        _body.rotation = Quaternion.Slerp( _body.rotation, Quaternion.LookRotation(_input.Look), _rotationSpeed * Time.deltaTime);
    }
}
