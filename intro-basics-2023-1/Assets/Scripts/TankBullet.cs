using UnityEngine;

public class TankBullet : MonoBehaviour {

    [SerializeField]
    private float _speed = 5;
    [SerializeField]
    private float _lifeTime = 3;

    private Rigidbody2D _rb;
    private float _creationTime = 0;

    private void Start() {

        _rb = GetComponent<Rigidbody2D>();
        _creationTime = Time.time;
        _rb.velocity = transform.up * _speed;
    }

    private void Update() {
        if (Time.time > _creationTime + _lifeTime) {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hit with " + other.name);
        DestroyProjectile();
    }

    private void DestroyProjectile() {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
