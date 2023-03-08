using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }
    
    [SerializeField] private float _lootChance;
    [SerializeField] private GameObject[] _lootPrefabs;

    private void Start()
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
            SpawnLoot();
        }
    }

    private void SpawnLoot()
    {
        if (Random.Range(0f, 1f) <= _lootChance)
        {
            var lootIdx = Random.Range(0, _lootPrefabs.Length);
            var loot = Instantiate(_lootPrefabs[lootIdx]);
            
            loot.transform.position = (Vector2)transform.position + Random.insideUnitCircle * 0.5f;
        }
    }
}
