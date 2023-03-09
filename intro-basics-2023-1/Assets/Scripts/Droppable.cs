using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
     [field: SerializeField]
     public int TotalHealthPoints { get; private set; }
     public int HealthPoints { get; private set; }

     [SerializeField]
     private GameObject[] _loot;
     private int _lootIndex;
     [SerializeField]
     private float _lootChance;
     private float _lootRandom;
     // Start is called before the first frame update
     void Start()
    {
       HealthPoints = TotalHealthPoints;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

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
               _lootIndex = Random.Range(0, 2);
               _lootRandom = Random.Range(0.0f, 1.0f);
               Vector2 objPos = new Vector2 (transform.position.x, transform.position.y);
               
               if (_lootRandom < _lootChance)
               {
                    Instantiate(_loot[_lootIndex], objPos + Random.insideUnitCircle, Quaternion.identity);
               }
          }
               
     }
}
