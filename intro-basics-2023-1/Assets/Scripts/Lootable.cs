using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    
    [Header("Rotation")]
    [SerializeField] private float _localRotationSpeed = 30f;

    private Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       IndependentRotation();
    }


     void IndependentRotation()
    {
        transform.RotateAround(transform.position, Vector3.forward, _localRotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
            Debug.Log("Loot grabbed by Player");
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        
    }

}
