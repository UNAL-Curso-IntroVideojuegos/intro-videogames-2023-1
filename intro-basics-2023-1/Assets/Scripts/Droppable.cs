using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField]
    private GameObject[] _loots;

    private int _probability;

    // Start is called before the first frame update
    void Start()
    {
        _probability = UnityEngine.Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        HealthPoints = TotalHealthPoints;
    }

    private void OnCollitionEnter2D(Collider2D other)
    {
        TakeHit();
        UnityEngine.Debug.Log("Choca");
    }

    public void TakeHit()
    {
        if (HealthPoints <= 0)
            return;

        HealthPoints--;
        if (HealthPoints <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

            if (_probability > 3)
            {
                GameObject loot = Instantiate(_loots[UnityEngine.Random.Range(0, _loots.Length)]);

                Vector2 position = UnityEngine.Random.insideUnitCircle;

                loot.transform.position = new Vector3(
                    transform.position.x + position.x,
                    transform.position.y + position.y,
                    0
                    );

            }
        }

    }
}
