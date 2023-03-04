using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _turnSpeed = 45;

    private Rigidbody2D _rb;

    private float _inputMagnitude;
    private float _rotAngle;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 _dir = new Vector2(horizontal, vertical);
        _dir.Normalize();

        _inputMagnitude = _dir.magnitude;

        //Body rotation
        if (_dir.sqrMagnitude > 0)
            _rotAngle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg - 90;
        else
            _rotAngle = _rb.rotation;
    }

    private void FixedUpdate()
    {
        _rb.rotation = Mathf.LerpAngle(_rb.rotation, _rotAngle, _turnSpeed * Mathf.Deg2Rad * Time.fixedDeltaTime);
        _rb.velocity = transform.up * _speed;
    }

}
