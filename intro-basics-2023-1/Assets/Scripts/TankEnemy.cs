using UnityEngine;

public class TankEnemy : MonoBehaviour {

    [SerializeField]
    private Transform _startPosition;
    [SerializeField]
    private Transform _endPosition;
    [SerializeField]
    private float _speed = 1.0f;

    [Space(20)]
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private Transform[] _cannons;
    [SerializeField]
    private Transform[] _shootPoints;
    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private float _waitTimeToShoot = 3;

    private float _timeLastShoot = 0;
    private float _journeyLength;
    private float _startTime;

    private bool _disabled = false;

    void Start() {
        _journeyLength = Vector3.Distance(_startPosition.position, _endPosition.position);
        gameObject.SetActive(false);
    }

    void OnDisable() {
        if(!_disabled) {
            _disabled = !_disabled;
        }
    }

    void OnEnable() {
        if(_disabled) {
            _startTime = Time.time;
            _disabled = !_disabled;
        }
    }

    void Update() {   
        //Cannon Rotations:
        Vector3 position = _player.position - transform.position;
        Vector3 aimVector = (position).normalized;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
        
        for(int i = 0; i < _cannons.Length; i++) {
            _cannons[i].rotation = Quaternion.Euler(0,0,angle);
        }

        _timeLastShoot += Time.deltaTime;

        if (_timeLastShoot > _waitTimeToShoot) {
            //Shoots
            for(int i = 0; i < _shootPoints.Length; i++) {
                GameObject projectile = Instantiate(_projectilePrefab);
                projectile.transform.position = _shootPoints[i].position;
                projectile.transform.rotation = _shootPoints[i].rotation;
            }

            _timeLastShoot = 0;
        }
    }

    void FixedUpdate() { 
        //Movement
        float distCovered = Mathf.PingPong((Time.time - _startTime) * _speed, _journeyLength);
        float fractionOfJourney = distCovered / _journeyLength;
        transform.position = Vector3.Lerp(_startPosition.position, _endPosition.position, fractionOfJourney);
    }
}
