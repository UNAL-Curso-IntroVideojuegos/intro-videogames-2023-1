using System;
using System.Collections;
using UnityEngine;

namespace SpaceShipNetwork.Gameplay
{
    public class Weapon : MonoBehaviour
    {
        public enum FireMod { Auto, Burst, Single};
        [SerializeField] FireMod _fireMod;

        [SerializeField] Transform[] _projectileSpawn = Array.Empty<Transform>();
        [SerializeField] Projectile _projectile;
        [SerializeField] float _msBetweenShots = 100;
        [SerializeField] float _projectileVelocity = 35;
        [SerializeField] int _burstCount;
        [SerializeField] int _projectilesPerMag;
        [SerializeField] float _reloadTime = .3f;

        public int _damage = 3;
        
        bool _isReloading;
        float _nextShotTime;
        bool _triggerReleasedSinceLastShoot;
        int _shotsRemainingInBurst;
        int _projectilesRemainingInMag;

        private ShipWeaponController _shipOwner;
        public void SetShipOwner(ShipWeaponController ship) => _shipOwner = ship;
        
        private void Start()
        {
            _shotsRemainingInBurst = _burstCount;
            _projectilesRemainingInMag = _projectilesPerMag;
        }

        private void LateUpdate()
        {
            if (!_isReloading && _projectilesRemainingInMag == 0)
                Reload();
        }

        void Shoot()
        {
            if (!_isReloading && Time.time > _nextShotTime && _projectilesRemainingInMag > 0)
            {
                if(_fireMod == FireMod.Burst)
                {
                    if (_shotsRemainingInBurst == 0)
                        return;
                    _shotsRemainingInBurst--;
                }
                else if(_fireMod == FireMod.Single)
                {
                    if (!_triggerReleasedSinceLastShoot)
                        return;
                }

                _nextShotTime = Time.time + _msBetweenShots / 1000;

                for (int i = 0; i < _projectileSpawn.Length; i++)
                {
                    if (_projectilesRemainingInMag == 0)
                        break;

                    _projectilesRemainingInMag--;
                    Projectile newProjectile = Instantiate(_projectile, _projectileSpawn[i].position, _projectileSpawn[i].rotation);
                    newProjectile.SetSpeed(_projectileVelocity);
                    newProjectile.SetDamage(_damage);
                    newProjectile.SetShipOwner(_shipOwner);
                }
            }
        }
        
        public void Reload()
        {
            if (!_isReloading && _projectilesRemainingInMag != _projectilesPerMag)
            {
                StartCoroutine(AnimateReload());
            }
        }
        
        IEnumerator AnimateReload()
        {
            _isReloading = true;

            yield return new WaitForSeconds(.2f);

            float percent = 0;
            float reloadSpeed = 1 / _reloadTime;

            while (percent < 1)
            {
                percent += Time.deltaTime * reloadSpeed;
                yield return null;
            }

            _isReloading = false;
            _projectilesRemainingInMag = _projectilesPerMag;
        }
        
        public void Aim(Vector3 aimPoint)
        {
            if(_isReloading)
                return;

            Vector3 dir = aimPoint - transform.position;
            dir.z = 0;
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        

        public void OnTriggerHold()
        {
            Shoot();
            _triggerReleasedSinceLastShoot = false;
        }

        public void OnTriggerRelease()
        {
            _triggerReleasedSinceLastShoot = true;
            _shotsRemainingInBurst = _burstCount;
        }

    }
}