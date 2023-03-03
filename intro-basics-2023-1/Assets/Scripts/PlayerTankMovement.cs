using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _turnSpeed = 45;
    [Space(20)]
    [SerializeField]
    private Transform _cannon;

    private float _inputMagnitude;
    private float _rotAngle;
    
    private Rigidbody2D _rb;
    private Camera _cam;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 _dir  = new Vector2(horizontal, vertical);
        _dir.Normalize();

        //Mouse Look
        Vector2 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = _cam.ScreenToWorldPoint(mousePos);
        mouseWorldPos.z = 0;
        
        _inputMagnitude = _dir.magnitude;

        //Body rotation
        if (_dir.sqrMagnitude > 0)
            _rotAngle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg - 90;
        else
            _rotAngle = _rb.rotation;
        
        //Cannon Rotation:
        Vector3 aimVector = (mouseWorldPos - transform.position).normalized;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
        
        _cannon.rotation = Quaternion.Euler(0,0,angle);

    }

    private void FixedUpdate()
    {
        _rb.rotation = Mathf.LerpAngle(_rb.rotation, _rotAngle, _turnSpeed * Mathf.Deg2Rad * Time.fixedDeltaTime);
        _rb.velocity = transform.up * _speed * _inputMagnitude;
    }
}
