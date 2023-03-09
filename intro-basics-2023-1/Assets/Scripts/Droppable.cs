using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour,IDamageable
{
    public int TotalHealthPoints { get { return maxHealth; } }
    public int HealthPoints { get { return currentHealth; } }

    public int maxHealth = 3;
    public float lootProbability = 0.5f;
    public GameObject[] possibleLoots;
    public float lootSpawnRadius = 1.0f;

    private int currentHealth;
    private Collider2D col;

    private void Start()
    {
        currentHealth = maxHealth;
        col = GetComponent<Collider2D>();
    }

    public void TakeHit()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            GenerateLoot();
            Destroy(gameObject);
        }
    }

    private void GenerateLoot()
    {
        if (Random.value < lootProbability)
        {
            int randomLootIndex = Random.Range(0, possibleLoots.Length);
            Vector2 lootSpawnPos = (Vector2)transform.position + Random.insideUnitCircle.normalized * lootSpawnRadius;
            Instantiate(possibleLoots[randomLootIndex], lootSpawnPos, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.velocity = Vector2.zero;
            }
        }
    }
}
