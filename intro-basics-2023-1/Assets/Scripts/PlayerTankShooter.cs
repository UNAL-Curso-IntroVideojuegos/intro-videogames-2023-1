using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Transform _shootPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot
            GameObject projectile = Instantiate(_projectilePrefab);
            projectile.transform.position = _shootPoint.position;
            projectile.transform.rotation = _shootPoint.rotation;
        }
        
    }
}
