using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{

    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Transform _shootPoint;
    
    [SerializeField]
    private Transform _shootPoint1;

    [SerializeField]
    private float _timeR=0.5f;

    private bool _timeRu = false;
    private float _timeRe;

    // Start is called before the first frame update
    void Start()
    {
        _timeRu=true;
        _timeRe=_timeR;
    }

    // Update is called once per frame
    void Update()
    {   
        if(_timeRu){
                if(_timeR<0){
                GameObject projectile = Instantiate(_projectilePrefab);
                projectile.transform.position = _shootPoint.position;
                projectile.transform.rotation = _shootPoint.rotation;

                GameObject projectile1 = Instantiate(_projectilePrefab);
                projectile1.transform.position = _shootPoint1.position;
                projectile1.transform.rotation = _shootPoint1.rotation;
                _timeR=_timeRe;
                }
        else{
            _timeR-=Time.deltaTime;
        }    
        }
    }
    
}
