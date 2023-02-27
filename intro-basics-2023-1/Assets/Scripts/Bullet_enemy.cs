using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7;
    
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * _speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        DestroyProjectile();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
