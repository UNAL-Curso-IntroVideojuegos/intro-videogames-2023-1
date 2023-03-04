using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField]
    private GameObject _self;
    [SerializeField]
    private GameObject _enemy;


    private void OnTriggerEnter2D(Collider2D collider) {

        if (collider.CompareTag("Player")){
            _self.SetActive(false);
            _enemy.SetActive(true);
        }
    }
}
