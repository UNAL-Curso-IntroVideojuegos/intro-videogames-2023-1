using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Transform[] _shootPoints;

    private float timeRemaining = 3;
    

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Time has run out");
            timeRemaining = 3;
            GameObject projectile1 = Instantiate(_projectilePrefab);
            projectile1.transform.position = _shootPoints[0].position;
            projectile1.transform.rotation = _shootPoints[0].rotation;
            
            GameObject projectile2 = Instantiate(_projectilePrefab);
            projectile2.transform.position = _shootPoints[1].position;
            projectile2.transform.rotation = _shootPoints[1].rotation;
        }
    }
}
