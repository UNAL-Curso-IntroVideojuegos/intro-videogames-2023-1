using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField] private GameObject _tankEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter " + other.name);
        _tankEnemy.SetActive(true);
    }
    
}
