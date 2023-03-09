using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints {  get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField]
    private float LootProbability;

    [SerializeField]
    private GameObject[] LootList;


    void Start()
    {
        HealthPoints = TotalHealthPoints;
    }

    public void TakeHit()
    {
        if (HealthPoints <= 0)
        {
            return;
        }
        HealthPoints--;
        if (HealthPoints <= 0)
        {
            gameObject.SetActive(false);
            Object.Destroy(gameObject);

            // Soltar Loot
            float r = Random.Range(0.0f, 1.0f);
            if (r <= LootProbability)
            {
                GameObject loot = Instantiate(LootList[Random.Range(0, LootList.Length)]);
                loot.transform.position = (Vector2) transform.position + Random.insideUnitCircle;
            }
        }
    }
}
