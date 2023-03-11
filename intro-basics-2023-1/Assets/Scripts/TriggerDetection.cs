using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{

	[SerializeField]
    private GameObject _enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.name== "PlayerTank"){
 		_enemy.SetActive(true);
 		gameObject.SetActive(false);
 	 }
        }

     
}
