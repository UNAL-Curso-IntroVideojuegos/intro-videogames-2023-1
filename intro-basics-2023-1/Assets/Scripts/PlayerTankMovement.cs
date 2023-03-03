using Unity.VisualScripting;
using UnityEngine;

public class PlayerTankMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1;
    [SerializeField]
    private float _turnSpeed = 45;
    
    [Space(20)]
    [SerializeField]
    private Transform _cannon;
    
    private Rigidbody2D _rb;
    private Camera _cam;
    
    // Compartidas en el Update y el FixedUpdate
    private float _inputMagnitude;
    private float _rotAngle;
    
    private void Start()
    {
        // Traiga el componente que tengo ya agregado
        _rb = GetComponent<Rigidbody2D>();
        
        /*
         * For look at mouse
         * Get active and principal camera
         */
        _cam = Camera.main;
    }
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 _dir  = new Vector2(horizontal, vertical);
        _dir.Normalize(); //Get Vector Direction

        //Mouse Look
        //get position of mouse in screen in pixels
        Vector3 mousePos = Input.mousePosition;
        //convert mouse position to world position
        Vector3 mouseWorldPos = _cam.ScreenToWorldPoint(mousePos);
        //for 2D World, set z to 0 (Good practice)
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
        // En teoría corren al mismo tiempo, pero este no es variable (40xs)
        // Si se van a cambiar las fisicas se usa el fiexedupdate
        
        // Receive an angle
        /*
         * _rb.rotation: Actual rotation
         * fixedDeltaDime: Time between frames for physics
         * ==== movement ====
         * _rb.rotation: Dont have fixedDeltaTime porque se espera una rapidez que es la magnitud 
         */
        _rb.rotation = Mathf.LerpAngle(_rb.rotation, _rotAngle, _turnSpeed * Mathf.Deg2Rad * Time.fixedDeltaTime);
        _rb.velocity = transform.up * _speed * _inputMagnitude;
    }
}
