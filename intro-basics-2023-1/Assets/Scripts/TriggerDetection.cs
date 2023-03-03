using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{

    [SerializeField]
    private Transform _enemyTank;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit with " + other.name);
        this.gameObject.SetActive(false);
        _enemyTank.gameObject.SetActive(true);
    }
}
