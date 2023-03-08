using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    [SerializeField]
    private float speed = 100;
    [SerializeField]
    private Transform centro;
    void Start()
    {    
    }
    void Update()
    {
        transform.RotateAround(centro.position, Vector3.forward, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Loot grabbed by Player");
        gameObject.SetActive(false);
    }
}