using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private float _speed = 5;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.Find("PlayerTank");
        Vector3 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg+90;
        _rb.velocity = (direction * _speed);
         }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit with " + other.collider.name);
        DestroyProjectile();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit with " + other.name);
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
