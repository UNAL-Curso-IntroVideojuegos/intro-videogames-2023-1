using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private LayerMask _collisionMask;
    [SerializeField]
    private float _lifeTime = 3;
    
    private float _speed = 7;
    private int _damage = 1;
    private float _destructionTime = 0;

    public void SetSpeed(float speed) => _speed = speed;
    public void SetDamage(int damage) => _damage = damage;
    
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
        
        float movementDistance = _speed * Time.deltaTime; //X = V * T
        Vector3 translation = Vector3.forward * movementDistance;
        CheckCollision(translation);
        transform.Translate(translation);
    }
    
    private void CheckCollision(Vector3 translation)
    {
        RaycastHit hit; 
        if (Physics.Raycast(transform.position, transform.forward, out hit, translation.magnitude, _collisionMask))
        {
            if (hit.transform.TryGetComponent(out IDamageable targetHit))
            {
                targetHit.TakeHit(_damage);
            }
            
            DestroyProjectile();
        }
    }
    
    private void DestroyProjectile()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
