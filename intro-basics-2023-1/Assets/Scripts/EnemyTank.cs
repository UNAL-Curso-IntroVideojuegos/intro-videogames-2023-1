using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{


    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _turnSpeed = 45;
    
    
    [SerializeField]
    private Transform[] _cannons;

    

    [SerializeField]
    private Transform _Player;

    [SerializeField]
    private Transform _initial_pos;

    [SerializeField]
    private Transform _end_pos;


    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Transform[] _shootPoints;

    [SerializeField]
    private float _XtimeShoot = 3.0f;


    private float _acumulatedTimeWithoutShoot = 0.0f;
    
    private Rigidbody2D _rb;

    private float _inputMagnitude;
    private float _rotAngle;
    


    // Start is called before the first frame update
    void Start()
    {  
        transform.gameObject.SetActive(false);
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        //Cannon Rotation
        Vector3 aimVector = (_Player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;


        foreach (Transform _cannon in _cannons)
       {
            _cannon.rotation = Quaternion.Euler(0,0,angle);
       }
        
        


        //Movement
        transform.position = Vector3.Lerp(_initial_pos.position, _end_pos.position, Mathf.PingPong(Time.time * _speed, 1.0f));


        //Shoot
        if(_acumulatedTimeWithoutShoot>_XtimeShoot){
            foreach (Transform _shootPoint in _shootPoints)
            {
                GameObject projectile = Instantiate(_projectilePrefab);
                projectile.transform.position = _shootPoint.position;
                projectile.transform.rotation = _shootPoint.rotation;
                
            }
            

            _acumulatedTimeWithoutShoot -= _XtimeShoot;
            
        }else{
            _acumulatedTimeWithoutShoot += Time.deltaTime;
        }
            
    }


    private void FixedUpdate()
    {

    }
}
