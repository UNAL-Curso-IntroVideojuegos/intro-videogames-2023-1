using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Activamos los sprites del tanque
        GameObject.Find("tankEnemy").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("barrel1").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("barrel2").GetComponent<SpriteRenderer>().enabled = true;
        
        // Desactivamos el muro de detección
        gameObject.SetActive(false);
    }
}
