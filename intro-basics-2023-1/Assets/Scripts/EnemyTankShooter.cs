using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShooter : MonoBehaviour
{
    // Start is called before the first frame update
    
    /*[SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private Transform _shootPoint1;
    [SerializeField]
    private Transform _shootPoint2;

    public float initialDelay=2.0f;
    public float timeBetweenShots=1.0f;
    void Start()
    {
         Invoke("Shoot", initialDelay);
    }

    // Update is called once per frame
    void Shoot()
    {
        GameObject projectile1 = Instantiate(_projectilePrefab, _shootPoint1.position, _shootPoint1.rotation);
        GameObject projectile2 = Instantiate(_projectilePrefab, _shootPoint2.position, _shootPoint2.rotation);
        Invoke("Shoot",timeBetweenShots);
    }
    
}*/
 [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform[] shootPoint;

    public float timeRemaining = 10;
    public float timeRemaining1 = 10;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                foreach (Transform i in shootPoint)
                {
                    GameObject projectile = Instantiate(projectilePrefab);
                    projectile.transform.position = i.position;
                    projectile.transform.rotation = i.rotation;
                }
                timeRemaining = timeRemaining1;
            }
        }
    }
}
