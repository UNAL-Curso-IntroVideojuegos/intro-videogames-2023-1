using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int _movementDirection = 1;
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private Animator _anim;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        ChangeDirection();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "PointA" || other.gameObject.name == "PointB")
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        _anim.SetInteger("DirectionWalk", _movementDirection);
        _movementDirection *= -1;
        _rb.velocity = transform.up * _speed * _movementDirection;
    }
}
