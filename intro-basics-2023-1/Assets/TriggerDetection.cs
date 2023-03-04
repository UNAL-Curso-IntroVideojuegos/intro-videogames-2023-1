using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{

    [SerializeField] private GameObject Enemy;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Enemy.SetActive(true);
        gameObject.SetActive(false);
    }
}
