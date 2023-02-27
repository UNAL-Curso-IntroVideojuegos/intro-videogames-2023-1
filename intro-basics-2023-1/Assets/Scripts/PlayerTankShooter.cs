using UnityEngine;

public class PlayerTankShooter : MonoBehaviour {

    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Transform _shootPoint;
    [SerializeField]
    private float _waitTimeToShoot = 1;

    private float _timeLastShoot = 0;
    
    
    void Update() {
        _timeLastShoot += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && _timeLastShoot > _waitTimeToShoot) {
            //Shoot
            GameObject projectile = Instantiate(_projectilePrefab);
            projectile.transform.position = _shootPoint.position;
            projectile.transform.rotation = _shootPoint.rotation;

            _timeLastShoot = 0;
        }
    }
}
