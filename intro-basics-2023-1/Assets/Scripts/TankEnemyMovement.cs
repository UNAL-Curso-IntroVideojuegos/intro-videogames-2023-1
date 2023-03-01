using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyMovement : MonoBehaviour
{

    [SerializeField]
    private Transform _playerTank;

    [SerializeField]
    private Transform[] _cannons;
    [SerializeField]
    private Transform _startPoint;
    [SerializeField]
    private Transform _endPoint;


    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {   
        Vector3 start = _startPoint.position;
        Vector3 end = _endPoint.position;
       
        // Divide to slow down the movement
        float alternatingValue = Mathf.PingPong(Time.time / 2, 1);

        Vector3 newPosition = Vector3.Lerp(start, end, alternatingValue);
        transform.position = newPosition;

        // Rotate cannons
        foreach (Transform cannon in _cannons) 
        {
          //Cannon Rotation
          Vector3 aimVector = (_playerTank.position - cannon.position).normalized;
          float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
          cannon.rotation = Quaternion.Euler(0,0,angle);
        }
    }

}
