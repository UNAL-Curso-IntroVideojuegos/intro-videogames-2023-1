using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{

    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField]
    private GameObject[] _loots;

    void Start()
    {
        HealthPoints = TotalHealthPoints;
    }

    void Update()
    {
        
    }

    public void TakeHit(){
         if(HealthPoints <= 0)
            return;

        HealthPoints--;

        if(HealthPoints <= 0){
            Destroy(gameObject);
            GameObject randomLoot = Instantiate(_loots[Random.Range(0,2)]);
            randomLoot.transform.position = transform.position + (Vector3)Random.insideUnitCircle;
        }
            
    }
}
