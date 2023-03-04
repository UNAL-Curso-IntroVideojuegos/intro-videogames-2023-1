using System.Security.Cryptography;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    [SerializeField]
    private GameObject _self;


    /*[SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _turnSpeed = 45;*/

    [Space(20)]
    [SerializeField]
    private Transform _player;


    [Space(20)]
    [SerializeField]
    private Transform[] _cannon;

    [Space(20)]
    [SerializeField]
    private Transform _initpos;
    [SerializeField]
    private Transform _endpos;

    private Rigidbody2D _rb;

    private float dist;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _self.SetActive(false);
    }

    void Update()    
    {
        dist = _initpos.position.y - _endpos.position.y;
        transform.position = Vector3.Lerp(_initpos.position, _endpos.position, Mathf.PingPong(Time.time, dist)/dist);

        foreach (Transform cannon in _cannon)
        {
            Vector3 aimVector = (_player.position - cannon.position).normalized;
            float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
            cannon.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}