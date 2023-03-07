using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    [SerializeField]
    private float _velocity = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Fixed the axis x and y to 0, and the z axis to rotate
        transform.Rotate(0, 0, Time.deltaTime * _velocity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Loot grabbed by Player.");
            //Destroy the object
            Destroy(gameObject);
        }
    }
}
