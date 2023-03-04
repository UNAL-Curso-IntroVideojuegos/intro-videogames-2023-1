using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShooter : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;


    [SerializeField] private Transform fireRightPosition;
    [SerializeField] private Transform fireLeftPosition;

    public float reloadDelay = 50;
    private bool _canShoot ;
    private float _currentDelay = 0;
        
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (_canShoot == false)
        {
            _currentDelay -= Time.deltaTime;
            if (_currentDelay <= 0)
            {
                _canShoot = true;
            }
        }

        if (_canShoot)
        {
            _canShoot = false;
            _currentDelay = reloadDelay;
            
            GameObject leftProjectile = Instantiate(enemyBullet);
            leftProjectile.transform.rotation = fireRightPosition.rotation;
            leftProjectile.transform.position = fireRightPosition.position;
            
        
            GameObject rightProjectile = Instantiate(enemyBullet);
            rightProjectile.transform.position = fireLeftPosition.position;
            rightProjectile.transform.rotation = fireLeftPosition.rotation;
        }
        
    }
    
}
