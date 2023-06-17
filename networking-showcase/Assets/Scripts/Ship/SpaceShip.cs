
using UnityEngine;

namespace SpaceShipNetwork.Gameplay
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ShipWeaponController))]
    public class SpaceShip : MonoBehaviour, IDamageable
    {
        [field: SerializeField] public int TotalHealthPoints { get; private set; } = 10;
        [field: SerializeField] public int HealthPoints { get; private set; }
        
        [SerializeField] private float _acceleration = 3f;
        [SerializeField] private float _desacceleration = 1f;
        [SerializeField] private float _maxSpeed = 1.6f;
        [SerializeField] private float _turnSpeed = 45;

        private Rigidbody2D _rb;
        private ShipWeaponController _weaponController;
        private Camera _cam;
        
        private float _speed = 0;
        private float _rotAngle;
        private bool isShooting;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _weaponController = GetComponent<ShipWeaponController>();
            _cam = Camera.main;

            HealthPoints = TotalHealthPoints;
        }
        
        void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            bool shooting = Input.GetMouseButton(0) || Input.GetMouseButtonDown(0);
            
            Vector3 aimPoint = _cam.ScreenToWorldPoint(Input.mousePosition);
            aimPoint.z = 0;
            if((transform.position - aimPoint).sqrMagnitude > 1)
                _weaponController.Aim(aimPoint);
            Debug.DrawLine(transform.position, aimPoint);
            
            Vector2 dir  = new Vector2(horizontal, vertical);
            dir.Normalize();

            if (dir.sqrMagnitude > 0)
            {
                _rotAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
                _speed += _acceleration * Time.deltaTime;
            }
            else
            {
                _speed -= _desacceleration * Time.deltaTime;
                _rotAngle = _rb.rotation;
            }
            
            _speed = Mathf.Clamp(_speed, 0, _maxSpeed);
            
            if(shooting)
                _weaponController.OnTriggerHold();
            else if(isShooting)
                _weaponController.OnTriggerRelease();
            isShooting = shooting;
        }
    
        private void FixedUpdate()
        {
            _rb.rotation = Mathf.LerpAngle(_rb.rotation, _rotAngle, _turnSpeed * Mathf.Deg2Rad * Time.fixedDeltaTime);
            _rb.velocity = transform.up * _speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
        }

        public void TakeHit(int damage, Vector3 position)
        {
            if(HealthPoints <= 0)
                return;
    
            HealthPoints -= damage;
            if (HealthPoints <= 0)
            {
                HealthPoints = 0;
                Death();
            }
        }

        private void Death()
        {
            gameObject.SetActive(false);
        }
        
        private void OnValidate()
        {
            HealthPoints = TotalHealthPoints;
        }
    }
    
}
