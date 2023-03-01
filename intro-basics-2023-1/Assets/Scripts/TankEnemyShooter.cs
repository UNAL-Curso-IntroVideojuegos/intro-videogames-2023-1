using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Transform[] _shootPoints;

    private float timeRemaining = 1.5f;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 1.5f;
            foreach (Transform shootPoint in _shootPoints) 
            {
                //Shoot
                GameObject projectile = Instantiate(_projectilePrefab);
                projectile.transform.position = shootPoint.position;
                projectile.transform.rotation = shootPoint.rotation;
            }
        }
    }
}
