using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    private float _time;

    void Start()
    {
        
    }

    void Update()
    {   
        _time += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, 20 * _time);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Debug.Log("Loot grabbed by Player");
        }
    }
}
