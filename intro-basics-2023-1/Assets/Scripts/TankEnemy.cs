using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{

    [SerializeField] 
    private Transform _initialPoint;
    [SerializeField] 
    private Transform _endPoint;
    [SerializeField]
    private Transform _playerTank;
    [SerializeField] 
    private float _speed = 0.5f;
    [SerializeField]
    private Transform[] cannons;
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Para que el tanque se mueva del punto inicial al final
        transform.position = Vector3.Lerp(_initialPoint.position, _endPoint.position, Mathf.PingPong(Time.time * _speed, 1f));
        
        // Para que los canones miren al tanque jugador
        Vector3 aimVector = (_playerTank.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg - 90;
        
        cannons[0].rotation = Quaternion.Euler(0, 0, angle);
        cannons[1].rotation = Quaternion.Euler(0, 0, angle);

    }
}
