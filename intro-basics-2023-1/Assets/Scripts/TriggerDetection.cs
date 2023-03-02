using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField]
    private GameObject _tankEnemy; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Tank appears
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "PlayerTank"){
            _tankEnemy.SetActive(true); //Activar enemigo
            transform.gameObject.SetActive(false); //Desactivar detector
        }
    }
}
