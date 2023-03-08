using UnityEngine;

public class PlayerTankMovement : MonoBehaviour{

    [SerializeField]
    private float _speed = 2;
    [SerializeField]
    private float _turnSpeed = 2;

    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject activationMark;
    
    [SerializeField]
    private Transform _cannon;
    
    private Rigidbody2D _rb;
    private Camera _cam;
    
    private float _inputMagnitude;
    private float _rotAngle;
    
    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
        enemy.SetActive(false);
    }

    void Update(){
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
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 270;
        
        _cannon.rotation = Quaternion.Euler(0,0,angle);
    }
    
    private void FixedUpdate(){
        _rb.rotation = Mathf.LerpAngle(_rb.rotation, _rotAngle, _turnSpeed * Mathf.Deg2Rad * Time.fixedDeltaTime);
        _rb.velocity = transform.up * _speed * _inputMagnitude;
    }

    	private void OnTriggerEnter2D(Collider2D col){
	     Debug.Log("Hit with " + col.name);
          activationMark.SetActive(false);
          Destroy(activationMark);
          enemy.SetActive(true);
     }

}