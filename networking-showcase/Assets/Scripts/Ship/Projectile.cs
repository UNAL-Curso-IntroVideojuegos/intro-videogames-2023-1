using Unity.Netcode;
using UnityEngine;
using UnityEngine.Pool;


namespace SpaceShipNetwork.Gameplay
{
    public class Projectile : NetworkBehaviour
    {
        [SerializeField] private float _lifeTime = 3; //sec
        [SerializeField] private LayerMask _collisionMask;
        [SerializeField] private GameObject _hitVFXPrefab;

        private ShipWeaponController shipOwner;
        private float _speed = 7;
        private int _damage = 3; //sec
        private float _destructionTime = 0;
        private Vector3 lastPosition;

        private IObjectPool<Projectile> _parentPool = null;
        
        public void SetShipOwner(ShipWeaponController ship) => shipOwner = ship;
        public void SetSpeed(float speed) => _speed = speed;
        public void SetDamage(int damage) => _damage = damage;
        public void SetParentPool(IObjectPool<Projectile> parentPool) => _parentPool = parentPool;
        
        private void OnEnable()
        {
            _destructionTime = Time.time + _lifeTime;
            lastPosition = transform.position;
        }

        private void Update()
        {
            if(!IsOwner)
                return;
            
            if (Time.time > _destructionTime)
            {
                DestroyProjectile();
                return;
            }

            transform.position += transform.up * _speed * Time.deltaTime;
        }

        private void FixedUpdate()
        {
            if(!IsOwner)
                return;
            
            Vector3 movement = transform.position - lastPosition;
            CheckCollision(movement);
            lastPosition = transform.position;
        }

        private void CheckCollision(Vector2 movement)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, movement.magnitude, _collisionMask);

            // If it hits something...
            if (hit.collider != null)
            {
                if (shipOwner && hit.collider.gameObject == shipOwner.gameObject)
                {
                    return;
                }
                
                if (hit.transform.TryGetComponent(out IDamageable targetHit))
                {
                    targetHit.TakeHit(_damage, hit.point);
                }
                
                if (_hitVFXPrefab)
                {
                    Instantiate(_hitVFXPrefab, transform.position, Quaternion.identity);
                }

                DestroyProjectile();
            }
        }

        private void DestroyProjectile()
        {
            if (_parentPool != null)
            {
                _parentPool.Release(this);
            }
            else
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}