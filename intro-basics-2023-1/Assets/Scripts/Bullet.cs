using UnityEngine;
public class Bullet : MonoBehaviour{

     [SerializeField]
     private float _speed = 7;
    
     private Rigidbody2D _rb;

     private void Start(){
          _rb = GetComponent<Rigidbody2D>();
          _rb.velocity = transform.up * _speed;
     }

	private void OnTriggerEnter2D(Collider2D col){
	     Debug.Log("Hit with " + col.name);
          DestroyProjectile();
     }

     private void DestroyProjectile(){
          gameObject.SetActive(false);
          Destroy(gameObject);
     }

}