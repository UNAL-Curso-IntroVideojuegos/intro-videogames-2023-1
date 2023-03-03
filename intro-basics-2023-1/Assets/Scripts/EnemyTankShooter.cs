using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShooter : MonoBehaviour
{

     [SerializeField]
     private GameObject _projectilePrefab;

     [SerializeField]
     private Transform[] _shootPoints;

     [SerializeField] private float _timeRemaining = 1;
     private bool _timerIsRunning = false;
     private float _timeRemainingInitial;

     private void Start()
     {
          _timerIsRunning = true;
          _timeRemainingInitial = _timeRemaining;
     }

     void Update()
     {
          if (_timerIsRunning)
          {
               if(_timeRemaining < 0)
               {

                   //Shoot
                    GameObject projectile = Instantiate(_projectilePrefab);
                    projectile.transform.position = _shootPoints[0].position;
                    projectile.transform.rotation = _shootPoints[0].rotation;
                    GameObject projectile2 = Instantiate(_projectilePrefab);
                    projectile2.transform.position = _shootPoints[1].position;
                    projectile2.transform.rotation = _shootPoints[1].rotation;
                    _timeRemaining = _timeRemainingInitial;
               }
               else
               {
                    _timeRemaining -= Time.deltaTime;
               }
          }
          
          
     }
}
