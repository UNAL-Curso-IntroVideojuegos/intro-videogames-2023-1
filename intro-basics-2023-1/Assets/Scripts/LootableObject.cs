using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LootableObject : MonoBehaviour
{
    [Space(20)]
    [SerializeField] private Transform _center;

    [SerializeField]
    private float _movementSpeed = 30f;

    /*[SerializeField] 
    private bool _disableOnDetection;*/
    
    //public UnityEvent OnDetection;

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
    }

    void RotateAround()
    {
        transform.RotateAround(_center.position, Vector3.forward, _movementSpeed * Time.deltaTime);
    }
    void Update()
    {
        RotateAround();
    }
}
