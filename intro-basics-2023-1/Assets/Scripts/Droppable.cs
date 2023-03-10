using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Droppable : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField] private GameObject loot1;
    
    [SerializeField] private GameObject loot2;

    private GameObject[] _loots;

    public float lootChance = 0.6f;
    
    
    
    void Start()
    {
        HealthPoints = TotalHealthPoints;
        _loots = new GameObject[2];
        _loots[0] = loot1;
        _loots[1] = loot2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeHit()
    {
        if(HealthPoints <= 0)
            return;
    
        HealthPoints--;
        if (HealthPoints <= 0)
        {
            gameObject.SetActive(false);
            float randNum = Random.value;


            if (randNum <= lootChance)
            {
                int indexLootChoosen = Random.Range(0, _loots.Length);
                Vector2 randomVector = Random.insideUnitCircle * 2;
                GameObject lootCreated =  Instantiate(_loots[indexLootChoosen]);
                Vector3 newPosition = transform.position + (Vector3) randomVector;
                lootCreated.transform.position = newPosition;
            }
            {
                
            }


        }
            
    }
}
