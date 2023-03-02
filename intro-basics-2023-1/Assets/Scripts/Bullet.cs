using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7;

    private Rigidbody2D _rb;
    private Animator _anim;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _rb.velocity = transform.up * _speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit with " + other.collider.name);
        _anim.SetTrigger("Destroy");
        //DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
