using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{

    [SerializeField] private Transform _InitPos, _EndPos;
    [SerializeField] private float _speed = 1;
    [SerializeField] private bool _dir = true;
    [SerializeField] private Transform[] _cannon;
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _projectilePrefab;
    public float timeRemaining = 1;


    void Start(){
        gameObject.SetActive(false);
    }

    void Update(){
        //Movement
        if (_dir)
            transform.Translate(new Vector3(0, _InitPos.position.y * _speed * Time.deltaTime, 0));
        else
            transform.Translate (new Vector3(0, _EndPos.position.y * _speed * Time.deltaTime, 0));
         
        if(transform.position.y >= _InitPos.position.y) {
            _dir = false;
        }
         
        if(transform.position.y <= _EndPos.position.y) {
            _dir = true;
        }

        //Cannon

        foreach (Transform item in _cannon)
        {
            Vector3 PosPlayer = _player.position;
            Vector3 aimVector = (PosPlayer - item.position).normalized;
            float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
            Vector3 rot1 = transform.eulerAngles;
            rot1.z = angle;
            item.eulerAngles = rot1;
        }

        if (timeRemaining > 0.1)
        {
            timeRemaining -= Time.deltaTime;
        } else{
            GameObject projectile1 = Instantiate(_projectilePrefab);
            GameObject projectile2 = Instantiate(_projectilePrefab);

            projectile1.transform.position = _cannon[0].position;
            projectile1.transform.rotation = Quaternion.Euler(0, 0, 180f)*_cannon[0].rotation;

            projectile2.transform.position = _cannon[1].position;
            projectile2.transform.rotation = Quaternion.Euler(0, 0, 180f)*_cannon[1].rotation;
            timeRemaining = 1;
        }

    }

}
