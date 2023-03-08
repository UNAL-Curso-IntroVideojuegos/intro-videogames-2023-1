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
    private float _probability = 0.8f;

    [SerializeField]
    private GameObject[] _lootPrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthPoints = TotalHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        float random = Random.value;
        Vector2 offset = Random.insideUnitCircle;
        
        if (random <= _probability) {
            Instantiate(_lootPrefabs[1], transform.position, Quaternion.identity);
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
