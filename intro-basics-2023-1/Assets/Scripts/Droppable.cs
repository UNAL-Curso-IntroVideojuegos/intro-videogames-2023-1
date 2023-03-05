using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField]
    private GameObject[] _lootPrefabs;
    [SerializeField]
    private float _lootChance = 0.5f;

    private float randomNumber;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }

    private void OnEnable()
    {
        HealthPoints = TotalHealthPoints;
    }

    public void TakeHit()
    {
        if(HealthPoints <= 0)
            return;
    
        HealthPoints--;
        if(HealthPoints <= 0)
            randomNumber = Random.Range(0.0f, 1.0f);
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            if (randomNumber < _lootChance)
            {
                Instantiate(_lootPrefabs[0], position + (Random.insideUnitCircle * 1.5f), Quaternion.identity);
            }
            else
            {
                Instantiate(_lootPrefabs[1], position + (Random.insideUnitCircle * 1.5f), Quaternion.identity);
            }
            gameObject.SetActive(false);
    }

    private void CheckCollision(Vector2 movement)
    {
        RaycastHit2D hit = Physics2D.Raycast(_rb.position, transform.up, movement.magnitude);
        
        // If it hits something...
        if (hit.collider != null)
        {
            if (hit.transform.TryGetComponent(out IDamageable targetHit))
            {
                targetHit.TakeHit();
            }
            
            
            DestroyProjectile();
        }
    }
    
    private void DestroyProjectile()
    {
        
        gameObject.SetActive(false);
        Destroy(gameObject);
        
    }
}
