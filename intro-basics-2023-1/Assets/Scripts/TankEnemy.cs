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

    public int constant = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(_initialPoint.position, _endPoint.position, Mathf.PingPong(Time.time * 0.5f, 1f));
    }   

    private void FixedUpdate()
    {
        
    }
}
