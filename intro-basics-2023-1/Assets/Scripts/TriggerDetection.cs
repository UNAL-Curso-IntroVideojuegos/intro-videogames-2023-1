using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{

    [SerializeField] 
    private GameObject _EnemyTank;
    
    

   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
            transform.gameObject.SetActive(false);
            _EnemyTank.SetActive(true);
        }
        
    }
    
}
