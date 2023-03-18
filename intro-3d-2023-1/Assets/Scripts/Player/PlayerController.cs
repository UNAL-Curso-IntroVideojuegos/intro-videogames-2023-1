using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private PlayerInput _input;


    private void Update()
    {
        Vector2 moveDirection = _input.Move;
        Vector3 pointToLook = _input.Look;
    }
}
