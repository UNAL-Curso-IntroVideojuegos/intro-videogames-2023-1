
using System.Runtime.CompilerServices;
using System.Globalization;
using System;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    [Header("Movement")] 
    [SerializeField]
    private Transform _start;
    [SerializeField]
    private Transform _end;
    [Space(20)]
    [Header("Cannon behavior")] 
    [SerializeField]
    private Transform _cannon1;
    [SerializeField]
    private Transform _cannon2;
    [SerializeField]
    private Transform _tank;
    [Space(20)]
    [Header("Bullets")] 
    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private Transform _shootPoint1;
    [SerializeField]
    private Transform _shootPoint2;

    public float _interval;
    private float _nextShot = 0f;

    void Start()
    {
        gameObject.SetActive(false);   
    }
    void Update(){
        float time = Mathf.PingPong(Time.time, 1f); 
        transform.position = Vector3.Lerp(_start.position, _end.position, time);

        Vector3 aimVector1 = (_tank.position - transform.position).normalized;
        float angle1 = Mathf.Atan2(aimVector1.y, aimVector1.x) * Mathf.Rad2Deg + 90;
        _cannon1.rotation = Quaternion.Euler(0,0,angle1);

        Vector3 aimVector2 = (_tank.position - transform.position).normalized;
        float angle2 = Mathf.Atan2(aimVector2.y, aimVector2.x) * Mathf.Rad2Deg + 90;
        _cannon2.rotation = Quaternion.Euler(0,0,angle2);

        if (Time.time >= _nextShot) {
            Disparar();
            }
        }

    void Disparar() {
        _nextShot = Time.time + _interval;
        GameObject bullet1 = Instantiate(_projectile);
        bullet1.transform.position = _shootPoint1.position;
        bullet1.transform.rotation = _shootPoint1.rotation;
        GameObject bullet2 = Instantiate(_projectile);
        bullet2.transform.position = _shootPoint2.position;
        bullet2.transform.rotation = _shootPoint2.rotation;
    }
}





        
