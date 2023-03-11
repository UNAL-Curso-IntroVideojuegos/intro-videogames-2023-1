using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    [SerializeField]
    private float _turnSpeed = 45;

    void Start()
    {
        
        //Cannon Rotation
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        LootRotation();
    }
    
    void LootRotation()
    {
        transform.Rotate(-1*Vector3.forward, _turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
        Debug.Log("Loot grabbed by Player");
    }
}
