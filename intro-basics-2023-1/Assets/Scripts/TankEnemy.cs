using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour

   
{
    public float _speed = 0.5f;
    [SerializeField]
    private Transform _position1;
    [SerializeField]
    private Transform _position2;
    [SerializeField]
    private Transform _cannon1;
    [SerializeField]
    private Transform _cannon2;
    [SerializeField]
    private Transform _playerTank;

    public float timeRemaining = 2;


    [SerializeField]
    private GameObject _projectilePrefab1;
    [SerializeField]
    private GameObject _projectilePrefab2;
    
    [SerializeField]
    private Transform _shootPoint1;
    [SerializeField]
    private Transform _shootPoint2;

    private void Start()
    {
        GameObject _gameObject = this.gameObject;
        _gameObject.SetActive(false);
    }
 
    void Update() {
        transform.position = Vector3.Lerp (_position1.position, _position2.position, Mathf.PingPong(Time.time, _speed));
        if (timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
        }
        else {
            ShootPlayer(_projectilePrefab1, _shootPoint1);
            ShootPlayer(_projectilePrefab2, _shootPoint2);
            timeRemaining = 2;
        }
        var dir = _playerTank.position - transform.position;
        var dirNormalized = dir.normalized;
        float angle = Mathf.Atan2(dirNormalized.y, dirNormalized.x) * Mathf.Rad2Deg + 90;
        _cannon1.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        _cannon2.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Player tank Look
      //
    }


    void ShootPlayer(GameObject prefab, Transform shootPoint){
        GameObject projectile = Instantiate(prefab);
        projectile.transform.position = shootPoint.position;
        projectile.transform.rotation = shootPoint.rotation;
    }
}