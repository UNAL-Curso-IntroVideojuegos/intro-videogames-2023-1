using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7;
    
    private Rigidbody2D _rb;

    private Transform playerTank;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        playerTank = FindObjectOfType<PlayerTankMovement>().transform;
        
    }

    private void Start()
    {
        Vector2 direction =  (playerTank.position - transform.position);
        _rb.velocity = direction.normalized * _speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit with " + other.collider.name);
        DestroyProjectile();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit with " + other.name);
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}