using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Transform[] _shootPoint;

    private float tiempofaltante = 4f;
    void Update()
    {
        if (tiempofaltante > 0)
        {
            tiempofaltante -= Time.deltaTime;
        }else
        {
            foreach (Transform _shootpoints in _shootPoint)
            {
                GameObject projectile = Instantiate(_projectilePrefab);
                projectile.transform.position = _shootpoints.position;
                projectile.transform.rotation = _shootpoints.rotation;
            }

            tiempofaltante = 5f;
            //Shoot
        }
    }
}
