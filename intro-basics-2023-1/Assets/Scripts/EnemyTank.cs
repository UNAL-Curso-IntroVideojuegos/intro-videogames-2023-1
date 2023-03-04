using System;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EnemyTank : MonoBehaviour
{
    [SerializeField]
    private GameObject _self;


    /*[SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _turnSpeed = 45;*/

    [Space(20)]
    [SerializeField]
    private Transform _player;

    [Space(20)]
    [SerializeField]
    private GameObject _prefab;


    [Space(20)]
    [SerializeField]
    private Transform[] _cannon;
    [SerializeField]
    private Transform[] _sp; //ShootPoints

    [Space(20)]
    [SerializeField]
    private Transform _initpos;
    [SerializeField]
    private Transform _endpos;

    private Rigidbody2D _rb;

    private float dist;

    private float _timer = 2;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _self.SetActive(false);
    }

    void Update()
    {
        //Movimiento lateral
        dist = _initpos.position.y - _endpos.position.y;
        transform.position = Vector3.Lerp(_initpos.position, _endpos.position, Mathf.PingPong(Time.time, dist) / dist);

        //Cannons
        foreach (Transform cannon in _cannon)
        {
            Vector3 aimVector = (_player.position - cannon.position).normalized;
            float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
            cannon.rotation = Quaternion.Euler(0, 0, angle);
        }
        
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            foreach (Transform sp in _sp)
            {
                GameObject projectile = Instantiate(_prefab);
                projectile.transform.position = sp.position;
                projectile.transform.rotation = sp.rotation;
            }
            _timer = 2;
            Debug.Log("Time has run out!");
        }
    }
}