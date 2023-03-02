using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyTankMovement : MonoBehaviour

{
    [SerializeField]
    private float _speed = 1;
    //[SerializeField]
    

    [SerializeField]
    private Transform _cannonE1;
    [SerializeField]
    private Transform _cannonE2;
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private float _pointA = -3; 
    [SerializeField]
    private float _pointB = 3; 

    private Rigidbody2D _rb;
    private float _targetY;
    private bool _movingToPointB = true;
    private float _changeDirectionDelay = 0.5f; 
    private float _timeSinceDirectionChange = 0f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _targetY = _pointB;
    }

    void Update()
    {


        Vector3 player_Position = _player.transform.position;

        //Cannon Rotation:
        Vector3 aimVector = (player_Position - transform.position).normalized;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;

        _cannonE1.rotation = Quaternion.Euler(0, 0, angle);
        _cannonE2.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void FixedUpdate()
    {
       
        if (Mathf.Abs(transform.position.y - _targetY) <= 0.1f)
        {
          
            _movingToPointB = !_movingToPointB;

            
            if (_movingToPointB)
            {
                _targetY = _pointB;
            }
            else
            {
                _targetY = _pointA;
            }

           
            _timeSinceDirectionChange = 0f;
        }
        else
        {
          
            float direction = (_targetY - transform.position.y) / Mathf.Abs(_targetY - transform.position.y);
            _rb.velocity = new Vector2(0, direction * _speed);

    
            if (_timeSinceDirectionChange < _changeDirectionDelay)
            {
                _timeSinceDirectionChange += Time.fixedDeltaTime;
            }
            else
            {
                _movingToPointB = !_movingToPointB;
                _timeSinceDirectionChange = 0f;
            }
        }
    }
}
