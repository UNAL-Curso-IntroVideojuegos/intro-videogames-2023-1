using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    [SerializeField]
    private float _speed = 50;
    [SerializeField]
    private LayerMask _collisionMaks;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward,_speed*Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            print("Loot grabbed by Player");
        }
    }
}
