using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droopeable : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [Space(20)]
    [SerializeField]
    private GameObject[] _LootsPrefab;

    //[SerializeField]
    //private GameObject _LootsPrefab1;

    float randomFloat;
    int randomIndex;
    GameObject randomPrefab;
    Vector2 randomSpawn;

    protected void OnEnable()
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


            this.randomFloat = UnityEngine.Random.value;

            if (randomFloat > 0.35f)
            {
                this.randomIndex = UnityEngine.Random.Range(0, _LootsPrefab.Length);

                this.randomPrefab = _LootsPrefab[randomIndex];

                Vector2 pos = transform.position;

                this.randomSpawn = UnityEngine.Random.insideUnitCircle * 1;

                Instantiate(this.randomPrefab, pos + randomSpawn, Quaternion.identity);

            }
        }
    }
}
