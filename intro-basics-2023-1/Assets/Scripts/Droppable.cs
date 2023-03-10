using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Droppable : MonoBehaviour, IDamageable
{

    [field: SerializeField]
    public int TotalHealthPoints { get; private set; }
    [field: SerializeField]
    public int HealthPoints { get; private set; }

  
    private Transform LootPos;
    [SerializeField]
    public float radio;
    [SerializeField]
    private GameObject[] looteables;

    private void Start()
    {
        HealthPoints = TotalHealthPoints;
    }

    public void TakeHit()
    {
        if (HealthPoints <= 0)
            return;

        HealthPoints--;
        if (HealthPoints <= 0)
        {
            gameObject.SetActive(false);
            GenerateLoot();
        }
    

    }

    private void GenerateLoot()
    {

        Vector3 LootPos =  Random.insideUnitCircle * radio;
        LootPos += transform.position;
        int n = Random.Range(0, looteables.Length);
        Instantiate(looteables[n], LootPos, Quaternion.identity);

       

    }
}
