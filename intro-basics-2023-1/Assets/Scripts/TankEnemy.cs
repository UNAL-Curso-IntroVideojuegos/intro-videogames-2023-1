using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _tank;

    [SerializeField]
    private float _speed = 0.4f;

    [Space(20)]
    [SerializeField]
    private Transform[] _cannons;

    [Space(20)]
    [SerializeField] private Transform _player;

    [Space(20)]
    [SerializeField] private Transform _initPos;

    [Space(20)]
    [SerializeField] private Transform _endPos;

    private Vector3 _init_position;
    private Vector3 _end_position;

    void Start()
    {
        _tank.SetActive(false);
        _init_position = _initPos.position;
        _end_position = _endPos.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(_init_position, _end_position, Mathf.PingPong(Time.time * _speed, 1.0f));

        Vector3 aimVector = (_player.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;

       foreach (Transform cannon in _cannons)
       {
            cannon.rotation = Quaternion.Euler(0, 0, angle);
       }

    }

}
