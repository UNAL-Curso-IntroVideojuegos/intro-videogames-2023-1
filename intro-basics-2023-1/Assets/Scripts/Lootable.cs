using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour{

     private Rigidbody2D _rb;
     [SerializeField]
     private LayerMask _collisionMask;
    
     void Start(){
          _rb = GetComponent<Rigidbody2D>();
     }

     // Update is called once per frame
     void Update(){
          _rb.rotation = _rb.rotation + 0.1f;
          Vector2 dir = transform.up;
          float _speed = 7;
          Vector2 movement = dir * _speed * Time.fixedDeltaTime;
          CheckCollision(movement);

     }

     private void CheckCollision(Vector2 movement){
          RaycastHit2D hit = Physics2D.Raycast(_rb.position, transform.up, movement.magnitude, _collisionMask);   

          if (hit.collider != null){
               Debug.Log("Loot grabbed by Player");
               DestroyLootable();
          }
     }

     private void DestroyLootable(){
          gameObject.SetActive(false);
          Destroy(gameObject);
     }
}
