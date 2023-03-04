using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTank;

    [SerializeField] private GameObject detector;
    
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("EnemyDetection"))
        {
            _enemyTank.SetActive(true);
            Destroy(collision);
            Destroy(detector);

        }
    }
}
