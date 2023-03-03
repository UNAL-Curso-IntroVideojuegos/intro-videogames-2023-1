using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShoot : MonoBehaviour
{
    private float timer = 1;
    [SerializeField] private Transform _shootPoint1;
    [SerializeField] private Transform _shootPoint2;
    [SerializeField] private GameObject _projectilePrefab;
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else {
            Shoot();
            timer = 1;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(_projectilePrefab);
        projectile.transform.position = _shootPoint1.position;
        projectile.transform.rotation = _shootPoint1.rotation * Quaternion.Euler(0, 180f, 0);

        GameObject projectile2 = Instantiate(_projectilePrefab);
        projectile2.transform.position = _shootPoint2.position;
        projectile2.transform.rotation = _shootPoint2.rotation * Quaternion.Euler(0, 180f, 0);
    }
}
