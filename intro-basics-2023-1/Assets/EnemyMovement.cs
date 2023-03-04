using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    [SerializeField]
    private Transform _cannon1;

    [SerializeField]
    private Transform _cannon2;
    
    private Rigidbody2D _rb;
    private GameObject _player;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("PlayerTank");
    }

    void Update()
    { 
        Vector3 playerpos =  _player.transform.position;

        Vector3 aimVector = (playerpos - transform.position).normalized;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
        
        _cannon1.rotation = Quaternion.Euler(0,0,angle);
        _cannon2.rotation = Quaternion.Euler(0,0,angle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name=="Position1" || other.name=="Position2"){
            _speed = -_speed; 
        }
        //Debug.Log("Hit with " + other.name);
          

    }
    private void FixedUpdate(){
        _rb.velocity = (Vector2)(transform.up*_speed);
    }
}
