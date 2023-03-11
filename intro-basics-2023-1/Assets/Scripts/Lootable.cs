using UnityEngine;

public class Lootable : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7;
    
    private Rigidbody2D _rb;

    [SerializeField]
    private LayerMask _collisionMask;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Vector2 dir = transform.up;
        Vector2 movement = dir * _speed * Time.fixedDeltaTime;
        CheckCollision(movement);
        transform.Rotate(new Vector3(0f,0f,30f) * Time.deltaTime);
    }

    private void CheckCollision(Vector2 movement)
    {
        RaycastHit2D hit = Physics2D.Raycast(_rb.position, transform.up, movement.magnitude, _collisionMask);
        
        // If it hits something...
        if (hit.collider != null)
        {
            Debug.Log("Loot grabbed by " + hit.collider.name);
            DestroyLootable();
        }
    }

    private void DestroyLootable()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
