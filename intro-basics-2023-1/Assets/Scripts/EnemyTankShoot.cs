using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShoot : MonoBehaviour
{

    [SerializeField]
    private Transform _player;

    [SerializeField]
    private Transform[] _cannon;
    
    [SerializeField]
    private GameObject _projectilePrefab;
    
    [SerializeField]
    private Transform[] _shootPoint;
    
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    	timer += Time.deltaTime;

        if (timer >= 2.0f)
        {	
        	foreach (Transform shootPoint in _shootPoint)
        	{
            GameObject projectile = Instantiate(_projectilePrefab);
            projectile.transform.position = shootPoint.position;
            projectile.transform.rotation = shootPoint.rotation;
             }
             timer = 0.0f;
        }
        
        foreach (Transform cannon in _cannon)
        {
            Vector3 aimVector = (_player.position - cannon.position).normalized;
            float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg - 90;
            cannon.rotation = Quaternion.Euler(0, 0, angle);
        }
       
    }
}
