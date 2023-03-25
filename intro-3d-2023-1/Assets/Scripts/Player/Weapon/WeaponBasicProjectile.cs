using System;
using UnityEngine;

public class WeaponBasicProjectile : Weapon
{
    [Space(20)]
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private float _projectileSpeed = 7f;
    [SerializeField] private int _projectileDamage = 1;
    
    private Transform _shootSpawnPoint;
    public void SetProjectileSpawnPoint(Transform spawnPoint) => _shootSpawnPoint = spawnPoint;
    

    protected override void Attack()
    {
        Projectile newProjectile = Instantiate(_projectilePrefab, _shootSpawnPoint.position, _shootSpawnPoint.rotation);
        newProjectile.SetSpeed(_projectileSpeed);
        newProjectile.SetDamage(_projectileDamage);
    }
    
}
