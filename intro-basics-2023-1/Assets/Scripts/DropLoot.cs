using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour, IDamageable
{

    [SerializeField]
    private GameObject[] _lootPrefab;

    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }

    public int HealthPoints { get; private set; }

    public float maxDistance = 1.0f;
    private Vector2 oldPosition;

    private void Start()
    {
        HealthPoints = TotalHealthPoints;
    }

    public void TakeHit()
    {

        Debug.Log(HealthPoints);

        if(HealthPoints <= 0)
            return;

        HealthPoints--;
        if(HealthPoints <= 0)
            gameObject.SetActive(false);
            int randomNumber = Random.Range(0, 2);
            GameObject loot = Instantiate(_lootPrefab[randomNumber]);
            oldPosition = transform.position;
            Vector2 offset = Random.insideUnitCircle * maxDistance;
            Vector2 newPosition = oldPosition + offset;
            loot.transform.position = newPosition;

    }
}
