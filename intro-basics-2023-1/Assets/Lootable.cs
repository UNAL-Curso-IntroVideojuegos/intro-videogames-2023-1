using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{

    [SerializeField] private int Degrees = 30;

    void Start()
    {
        
    }

    void Update()
    {
    transform.Rotate(new Vector3(0, 0, Degrees) * Time.deltaTime);    
    }

    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("Loot grabbed by Player");
        Destroy(gameObject);
    }
}
