using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1;
    
    [SerializeField]
    private Transform _playetTank;

    [Space(20)]
    [SerializeField]
    private Transform[] _cannons;
    
    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Transform[] _shootPoints;

    private Rigidbody2D _rb;

    private float _sentido; 
    
    private float _timeToShot = 3;

    private void Start()
    {
        gameObject.SetActive(false);
        _rb = GetComponent<Rigidbody2D>();
        _sentido = 1;
    }
    
    void Update()
    {
        //Cannon Rotation
        Vector3 aimVector = (_playetTank.position - _cannons[0].position).normalized;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg - 90;
        
        _cannons[0].rotation = Quaternion.Euler(0,0,angle);

        Vector3 aimVector2 = (_playetTank.position - _cannons[1].position).normalized;
        float angle2 = Mathf.Atan2(aimVector2.y, aimVector2.x) * Mathf.Rad2Deg - 90;
        
        _cannons[1].rotation = Quaternion.Euler(0,0,angle2);

        if (_timeToShot <= 0) 
        {
            //Shoot
            GameObject projectile = Instantiate(_projectilePrefab);
            projectile.transform.position = _shootPoints[0].position;
            projectile.transform.rotation = _shootPoints[0].rotation;

            GameObject projectile2 = Instantiate(_projectilePrefab);
            projectile2.transform.position = _shootPoints[1].position;
            projectile2.transform.rotation = _shootPoints[1].rotation;

            _timeToShot = 3;
        } else {
            _timeToShot -= Time.deltaTime;
        }
    }
    
    private void FixedUpdate()
    {
        _rb.velocity = transform.up * _speed * _sentido;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PuntoChoque>())
        {
            _sentido = -1*_sentido;
        }
    }

}
