using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{

    [SerializeField]
    private float _speed = 20;
    [SerializeField]
    private LayerMask _collisionMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IndependentRotation();
    }

    void IndependentRotation()
        {
            transform.Rotate(Vector3.forward,_speed*Time.deltaTime);
        }

    private void OnTriggerEnter2D(Collider2D col){
        gameObject.SetActive(false);
        Destroy(gameObject);
        Debug.Log("Loot grabbed by Player");
    
    }
}
