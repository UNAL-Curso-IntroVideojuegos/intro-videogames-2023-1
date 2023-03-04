using UnityEngine;
using UnityEngine.Pool;

public class PlayerTankShooter : MonoBehaviour
{
    [SerializeField]
    private Bullet _projectilePrefab;

    [SerializeField]
    private Transform _shootPoint;

    private IObjectPool<Bullet> _projectilePool;

    private void Awake()
    {
        _projectilePool =
            new ObjectPool<Bullet>(CreateProjectile, OnGetProjectile, OnRelease, OnDestroyProjectile, false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot
            _projectilePool.Get();
        }
    }

    private Bullet CreateProjectile()
    {
        Bullet projectile = Instantiate(_projectilePrefab);
        projectile.SetParentPool(_projectilePool);
        return projectile;
    }

    private void OnGetProjectile(Bullet projectile)
    {
        projectile.transform.position = _shootPoint.position;
        projectile.transform.rotation = _shootPoint.rotation;
        projectile.gameObject.SetActive(true);
    }

    private void OnRelease(Bullet projectile)
    {
        projectile.gameObject.SetActive(false);
    }

    private void OnDestroyProjectile(Bullet projectile)
    {
        Destroy(projectile.gameObject);
    }
    
}