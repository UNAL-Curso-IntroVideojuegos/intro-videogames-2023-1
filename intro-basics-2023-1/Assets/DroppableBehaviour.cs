using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppableBehaviour : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField] private List<GameObject> Drops;

    [SerializeField] private float dropChance = 0.8f;

 

    private void Start()
    {
        HealthPoints = TotalHealthPoints;

    }

    public void TakeHit()
    {
        HealthPoints--;
        if (HealthPoints <= 0) { 
            gameObject.SetActive(false);
            DropOnDeath();
        }
    }

    private void DropOnDeath() {
        if (Random.Range(0.0f, 1.0f) >= dropChance)
        {
            Debug.Log("No hay drop");
            return;
        }
        int dropitem = Random.Range(0, Drops.Count);
        GameObject drop = Instantiate(Drops[dropitem]);
        drop.transform.position = gameObject.transform.position;
        drop.transform.position += (Vector3)Random.insideUnitCircle;

    }
        

}

