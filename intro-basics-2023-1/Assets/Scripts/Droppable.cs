using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField]
    private float _lootChance;

    [SerializeField]
    private Transform[] _lootPrefabs;

    private float _radius = 3f;
    private float _randomValue;
    private int _randomOption;
    
    private void OnEnable()
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
            _randomValue = Random.value;
            Debug.Log(_randomValue);
            if (_randomValue > _lootChance)
            {
                _randomOption = Random.Range(0, _lootPrefabs.Length);
                InstantiateLoot(_randomOption);
            }
            gameObject.SetActive(false);
        }
    
    }

    void InstantiateLoot(int position)
    {
        Vector2 randomPos = Random.insideUnitCircle;
        Vector3 scPos = new Vector3(randomPos.x, 0f, randomPos.y) * _radius;
        Instantiate(_lootPrefabs[position], transform.position + scPos, Quaternion.identity);
    }
}
