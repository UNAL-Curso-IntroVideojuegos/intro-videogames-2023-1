using UnityEngine;
public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * _speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enemy bullet Hit with " + col.name);
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}