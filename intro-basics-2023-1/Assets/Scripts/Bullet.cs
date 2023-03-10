using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    private float _speed = 7;
    [SerializeField] private float _lifeTime = 3; //sec

    private Rigidbody2D _rb;
    private float _creationTime = 0;

    private Animator _anim;

    private IObjectPool<Bullet> _parentPool = null;

    public void SetParentPool(IObjectPool<Bullet> parentPool) => _parentPool = parentPool;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _rb.velocity = transform.up * _speed;
        _creationTime = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.TryGetComponent(out IDamageable targetHit))
        {
            targetHit.TakeHit();
        }

        _anim.SetTrigger("Destroy");
    }

    private void Update()
    {
        if (Time.time > _creationTime + _lifeTime)
        {
            DestroyProjectile();
        }
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
