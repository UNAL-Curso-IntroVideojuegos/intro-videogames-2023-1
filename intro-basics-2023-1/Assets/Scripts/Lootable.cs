using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    [Space(20)]
    [SerializeField] private Transform _center;

    [Header("Movement")]
    [SerializeField] private float _movementSpeed = 30f; // degrees/sec

    void Update()
    {
        RotateAround();
    }

    void RotateAround()
    {
        transform.RotateAround(_center.position, Vector3.forward, _movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Loot grabbed by Player");
        Destroy(gameObject);
    }
}
