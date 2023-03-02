using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{

    [SerializeField]
    private Transform _enemyTank;

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit with " + other.name);
        this.gameObject.SetActive(false);
        _enemyTank.gameObject.SetActive(true);
    }
}
