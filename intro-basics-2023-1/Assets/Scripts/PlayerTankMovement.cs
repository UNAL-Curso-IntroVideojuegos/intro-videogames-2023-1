using UnityEngine;

public class PlayerTankMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;
    [SerializeField]
    private float _turnSpeed = 45;
    
    [Space(20)]
    [SerializeField]
    private Transform _cannon;
    
    private Rigidbody2D _rb;
    private Camera _cam;

    private float _inputMagnitude;
    private float _rotAngle;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
    }
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 _dir  = new Vector2(horizontal, vertical);
        _dir.Normalize(); //Direction

        //Mouse Look
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = _cam.ScreenToWorldPoint(mousePos);
        mouseWorldPos.z = 0;

        _inputMagnitude = _dir.magnitude;
        
        //Body rotation
        if (_dir.sqrMagnitude > 0)
            _rotAngle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg - 90;
        else
            _rotAngle = _rb.rotation;

        //Cannon Rotation
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
