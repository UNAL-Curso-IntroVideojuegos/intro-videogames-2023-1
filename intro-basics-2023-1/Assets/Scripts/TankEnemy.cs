using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _tank;

    [SerializeField]
    private float _speed = 0.3f;

    [SerializeField]
    private Transform[] _cannons;

    [SerializeField]
    private Transform _playerTank;

    [SerializeField]
    private Transform _initPos;
    
    [SerializeField]
    private Transform _endPos;

    private Vector3 initPosition;
    private Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        _tank.SetActive(false);
        initPosition = _initPos.position;
        endPosition = _endPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(initPosition, endPosition, Mathf.PingPong(Time.time * _speed, 1.0f));

        Vector3 aimVector = (_playerTank.position - transform.position).normalized;
        float rotAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;

        foreach (Transform cannon in _cannons)
        {
            cannon.rotation = Quaternion.Euler(0, 0, rotAngle);
        }
    }
}
