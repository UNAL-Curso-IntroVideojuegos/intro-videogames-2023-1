using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f; // degrees/sec

    [SerializeField] private Transform center;

    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(center.position, Vector3.forward, movementSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Loot grabbed by Player");
        gameObject.SetActive(false);
    }
}
