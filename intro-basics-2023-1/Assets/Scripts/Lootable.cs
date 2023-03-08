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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
