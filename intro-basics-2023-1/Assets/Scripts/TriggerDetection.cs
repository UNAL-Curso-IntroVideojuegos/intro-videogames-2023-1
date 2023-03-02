using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField]
    private GameObject _tank;

    [SerializeField]
    private GameObject _detection_zone;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        _detection_zone.SetActive(false);
        _tank.SetActive(true);
    }
}