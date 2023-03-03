using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
     [SerializeField] private GameObject _enemyGameObject;
     [SerializeField] private GameObject _zone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D collision)
     {
          _enemyGameObject.SetActive(true);
          _zone.SetActive(false);
     }
}
