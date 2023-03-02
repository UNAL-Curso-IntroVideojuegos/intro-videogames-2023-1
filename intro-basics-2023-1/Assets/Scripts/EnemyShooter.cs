using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Transform _shootPoint1;
    [SerializeField]
    private Transform _shootPoint2;

    [SerializeField]
    private float _sleep;

    bool go = false;

    IEnumerator ShootCoroutine()
    {

        while (go != false)
        {

            if (go != false)
            {
                GameObject projectile1 = Instantiate(_projectilePrefab);
                projectile1.transform.position = _shootPoint1.position;
                projectile1.transform.rotation = _shootPoint1.rotation;

                GameObject projectile2 = Instantiate(_projectilePrefab);
                projectile2.transform.position = _shootPoint2.position;
                projectile2.transform.rotation = _shootPoint2.rotation;
                yield return new WaitForSeconds(_sleep);

            }
        }
       
            
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        go = true;
        StartCoroutine(ShootCoroutine());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        go = false;
        StartCoroutine(ShootCoroutine());
    }


}
