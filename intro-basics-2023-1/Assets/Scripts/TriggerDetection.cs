using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
  
    [SerializeField]
    private GameObject _enemyTank;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _enemyTank.SetActive(true);
        gameObject.SetActive(false);
    }
}
