using SpaceShipNetwork.Events;
using Unity.Netcode;
using UnityEngine;

namespace SpaceShipNetwork.Gameplay
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(ShipWeaponController))]
    public class SpaceShip : NetworkBehaviour, IDamageable
    {
        [field: SerializeField] public int TotalHealthPoints { get; private set; } = 10;
        [field: SerializeField] public int HealthPoints { get; private set; }
        
        [SerializeField] private float _acceleration = 3f;
        [SerializeField] private float _desacceleration = 1f;
        [SerializeField] private float _maxSpeed = 1.6f;
        [SerializeField] private float _turnSpeed = 45;

        private NetworkVariable<int> NetworkHealth = new NetworkVariable<int>(default, NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server);

        private Rigidbody2D _rb;
        private ShipWeaponController _weaponController;
        private Camera _cam;
        
        private float _speed = 0;
        private float _rotAngle;
        private bool isShooting;

        private void Start()
        {
            Initialize();
        }

        public override void OnNetworkSpawn()
        {
            Initialize();
            
            base.OnNetworkSpawn();
            
            NetworkHealth.OnValueChanged += OnNetworkHealthChanged;
            
            GameDelegates.EmitLocalPlayerSpawned(this);
        }

        public override void OnNetworkDespawn()
        {
            NetworkHealth.OnValueChanged -= OnNetworkHealthChanged;
        }
        
        private void Initialize()
        {
            _rb = GetComponent<Rigidbody2D>();
            _weaponController = GetComponent<ShipWeaponController>();
            _cam = Camera.main;

            HealthPoints = TotalHealthPoints;
            if (IsServer)
                NetworkHealth.Value = HealthPoints;
        }
        
        void Update()
        {
            if(!GameManager.Instance.IsGamePlaying)
                return;
            
            if (!IsOwner)
                return;
            
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector2 input  = new Vector2(horizontal, vertical);
            bool shooting = Input.GetMouseButton(0) || Input.GetMouseButtonDown(0);
            
            Vector3 aimPoint = _cam.ScreenToWorldPoint(Input.mousePosition);
            aimPoint.z = 0;
            if((transform.position - aimPoint).sqrMagnitude > 1)
                _weaponController.Aim(aimPoint);
            Debug.DrawLine(transform.position, aimPoint);
            
            if(shooting)
                _weaponController.OnTriggerHold();
            else if(isShooting)
                _weaponController.OnTriggerRelease();
            isShooting = shooting;
            
            //Server Auth movement
            HandleMovementServerRPC(input.normalized);
        }
    
        private void FixedUpdate()
        {
            //Server Auth Movement
            if (!IsServer)
                return;
            
            _rb.rotation = Mathf.LerpAngle(_rb.rotation, _rotAngle, _turnSpeed * Mathf.Deg2Rad * Time.fixedDeltaTime);
            _rb.velocity = transform.up * _speed;
        }
        
        public void TakeHit(int damage, Vector3 position)
        {
            if(HealthPoints <= 0)
                return;
    
            HealthPoints -= damage;
            if (IsServer)
                NetworkHealth.Value = HealthPoints;
            
            if (HealthPoints <= 0)
            {
                HealthPoints = 0;
                Death();
            }
        }

        private void OnNetworkHealthChanged(int previous, int current)
        {
            HealthPoints = current;
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

#region Server
        private void ProcessInput(Vector2 input)
        {
            if (input.sqrMagnitude > 0)
            {
                _rotAngle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg - 90;
                _speed += _acceleration * Time.deltaTime;
            }
            else
            {
                _speed -= _desacceleration * Time.deltaTime;
                _rotAngle = _rb.rotation;
            }
            
            _speed = Mathf.Clamp(_speed, 0, _maxSpeed);
        }
#endregion

#region RPCs
        [ServerRpc(RequireOwnership = false)]
        private void HandleMovementServerRPC(Vector2 input)
        {
           ProcessInput(input);
        }
#endregion
    }
    
}
