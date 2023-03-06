using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7;
    [SerializeField]
    private LayerMask _collisionMaks;
    
    [SerializeField]
    private float _lifeTime = 3; //sec
    [SerializeField]
    private GameObject _hitVFXPrefab;
    
    private Rigidbody2D _rb;
    private float _destructionTime = 0;

    private IObjectPool<Bullet> _parentPool = null;

    public void SetParentPool(IObjectPool<Bullet> parentPool) => _parentPool = parentPool;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _destructionTime = Time.time + _lifeTime;
    }

    private void Update()
    {
        if (Time.time > _destructionTime )
        {
            DestroyProjectile();
        }
    }
    
    private void FixedUpdate()
    {
        Vector2 dir = transform.up;
        Vector2 movement = dir * _speed * Time.fixedDeltaTime;
        Vector2 pos = _rb.position + movement;

        CheckCollision(movement);
        
        _rb.MovePosition(pos);
    }
    
    private void CheckCollision(Vector2 movement)
    {
        RaycastHit2D hit = Physics2D.Raycast(_rb.position, transform.up, movement.magnitude, _collisionMaks);
        
        // If it hits something...
        if (hit.collider != null)
        {
            if (hit.transform.TryGetComponent(out IDamageable targetHit))
            {
                targetHit.TakeHit();
            }
            
           
            
            if (_hitVFXPrefab)
            {
                Instantiate(_hitVFXPrefab, _rb.position, Quaternion.identity);
            }
            
            DestroyProjectile();
        }
    }
    
    private void DestroyProjectile()
    {
        if (_parentPool != null)
        {
            _parentPool.Release(this);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
