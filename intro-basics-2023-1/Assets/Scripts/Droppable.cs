using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField]
    private GameObject[] _lootables;
    [SerializeField]
    private float _probilityGen = 0.5f;
    [SerializeField]
    private float _minRadius = 1f;
    [SerializeField]
    private float _maxRadius = 5f;

    private void OnEnable()
    {
        HealthPoints = TotalHealthPoints;
    }
    public void TakeHit()
    {
        if (HealthPoints <= 0)
            return;
        Debug.Log("The points of Heath is: " + HealthPoints);
        HealthPoints--;
        if (HealthPoints <= 0)
        {
            GeneratesLootable();
            Destroy(gameObject);
        }
            
    }

    void GeneratesLootable()
    {
        if (Random.value >= _probilityGen) //Random.Range
        {
            float distance = Random.Range(_minRadius, _maxRadius);
            Vector2 randomOffset = Random.insideUnitCircle;
            Vector3 randomPosition = transform.position + new Vector3(randomOffset.x, 0, randomOffset.y) * distance;
            GameObject lootable = _lootables[Random.Range(0, _lootables.Length)]; 
            Instantiate(lootable, randomPosition, Quaternion.identity);
        }    
        
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

}
