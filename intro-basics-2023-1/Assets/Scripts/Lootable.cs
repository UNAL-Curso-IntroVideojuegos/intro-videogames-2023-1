using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    private Vector3 angle;
    [SerializeField]
    private float rotationSpeed = 30; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        angle += new Vector3(0, 0, 1) * Time.deltaTime * rotationSpeed;
        transform.eulerAngles = angle;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Loot grabbed by " + other.name);
        Destroy(this.GameObject());
    }
}

