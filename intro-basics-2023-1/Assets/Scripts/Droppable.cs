using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Droppable : MonoBehaviour, IDamageable
{
    [SerializeField] private int totalHealthPoints = 1;
    [SerializeField] private UnityEvent onDetection;
    [SerializeField] private GameObject[] possibleLoots;
    [SerializeField] [Range(0, 1)] private float lootProbability = 0.5f;
    private int healthPoints;

    public int TotalHealthPoints => totalHealthPoints;
    public int HealthPoints => healthPoints;

    private void Start()
    {
        healthPoints = TotalHealthPoints;
    }

    public void TakeHit()
    {
        if (HealthPoints <= 0)
        {
            return;
        }

        healthPoints--;

        if (HealthPoints <= 0)
        {
            if (Random.value <= lootProbability)
            {
                Vector2 lootPosition = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
                int randomLootIndex = Random.Range(0, possibleLoots.Length);
                GameObject loot = Instantiate(possibleLoots[randomLootIndex], lootPosition, Quaternion.identity);
            }

            onDetection?.Invoke();
            gameObject.SetActive(false);
            
            foreach (GameObject loot in possibleLoots)
            {
                loot.SetActive(true);
            }
        }
    }
}