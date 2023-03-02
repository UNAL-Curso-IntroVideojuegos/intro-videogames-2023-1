using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Transform[] _shootPoints;

    public float timeRemaining;

    void Start()
    {
        timeRemaining = 2;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            foreach (Transform shootPoint in _shootPoints)
            {
                GameObject projectile = Instantiate(_projectilePrefab);
                projectile.transform.position = shootPoint.position;
                projectile.transform.rotation = shootPoint.rotation;
            }
            timeRemaining = 3;
        }
    }

}

