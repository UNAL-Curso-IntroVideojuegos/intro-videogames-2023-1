using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Droppable : MonoBehaviour, IDamageable
{
    
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField]
    private float _probability = 0.1f;

    [SerializeField]
    private GameObject[] _lootPrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthPoints = TotalHealthPoints;
    }
    
    private void OnDisable()
    {
        float random = Random.value;

        if (random <= _probability)
        {
            int posibleLoot = Random.Range(0, _lootPrefabs.Length);
            Vector3 positionLoot = Random.insideUnitCircle;
            positionLoot += transform.position;
            Instantiate(_lootPrefabs[posibleLoot], positionLoot, Quaternion.identity);
        }

    }

    public void TakeHit()
    {
        if(HealthPoints <= 0)
            return;
    
        HealthPoints--;
        if(HealthPoints <= 0)
            gameObject.SetActive(false);
    }
}
