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
        private Vector3? targetCollisionPoint;

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
            if (!IsServer)
            {
                if (targetCollisionPoint.HasValue && (transform.position - targetCollisionPoint.Value).magnitude < .3f)
                {
                    DestroyProjectile();
                    SpawnHitVFX();
                }
                return;
            }

            if (Time.time > _destructionTime)
            {
                DestroyProjectile();
                return;
            }
            transform.position += transform.up * _speed * Time.deltaTime;
        }

        private void FixedUpdate()
        {
            if(!IsServer)
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
                
                OnCollisionDetectionClientRPC(hit.point);
                DestroyProjectile();
            }
        }

        private void DestroyProjectile()
        {
            gameObject.SetActive(false);
            if(IsServer)
                Destroy(gameObject, 1.5f);


            // if (_parentPool != null)
            // {
            //     _parentPool.Release(this);
            // }
            // else
            // {
            //     gameObject.SetActive(false);
            //     Destroy(gameObject);
            // }
        }

        private void SpawnHitVFX()
        {
            if (_hitVFXPrefab)
                Instantiate(_hitVFXPrefab, targetCollisionPoint ?? transform.position, Quaternion.identity);
        }
        
        #region RPCs
        [ClientRpc]
        private void OnCollisionDetectionClientRPC(Vector3 point)
        {
            targetCollisionPoint = point;
            if (IsServer)
                SpawnHitVFX();
        }
        #endregion
    }
}