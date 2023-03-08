using UnityEngine;
public class Bullet : MonoBehaviour{

     [Space(20)] 
     [SerializeField]
     private GameObject _hitVFXPrefab;

     [SerializeField]
     private float _speed = 7;
     [SerializeField]
     private LayerMask _collisionMask;
     [SerializeField]
     private float _lifeTime = 3; //sec
    
     private Rigidbody2D _rb;
     private float _creationTime = 0;

     private void Start(){
          _rb = GetComponent<Rigidbody2D>();
          _creationTime = Time.time;
     }

     private void Update(){
          if (Time.time > _creationTime + _lifeTime){
               if (_creationTime != 0){
                    DestroyProjectile();
               }
          }
     }

     private void FixedUpdate(){
          Vector2 dir = transform.up;
          Vector2 movement = dir * _speed * Time.fixedDeltaTime;
          Vector2 pos = _rb.position + movement;

          CheckCollision(movement);
          _rb.MovePosition(pos);
     }

     private void CheckCollision(Vector2 movement){
          RaycastHit2D hit = Physics2D.Raycast(_rb.position, transform.up, movement.magnitude,_collisionMask);   
          // If it hits something...

          if (hit.collider != null){
               Debug.Log("Hit with " + hit.collider.name);
               
               if (hit.transform.TryGetComponent(out IDamageable targetHit)) {
                    targetHit.TakeHit();
               }

               if (_hitVFXPrefab){
                    Instantiate(_hitVFXPrefab, _rb.position, Quaternion.identity);
               }

               DestroyProjectile();
          }
     }

     private void DestroyProjectile(){
          gameObject.SetActive(false);
          Destroy(gameObject);
     }

}