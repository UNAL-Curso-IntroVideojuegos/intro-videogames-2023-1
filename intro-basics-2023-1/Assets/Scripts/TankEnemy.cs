using System;
using UnityEngine;
using UnityEngine.Serialization;

public class TankEnemy : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField]
    private GameObject _deadVFXPrefab;
    
    [Space(20)]
    [SerializeField]
    private float _speed = 1;
    
    [FormerlySerializedAs("_initPos")]
    [Space(20)]
    [SerializeField]
    private Transform _initPosTransform;
    [FormerlySerializedAs("_endPos")] [SerializeField]
    private Transform _endPosTransform;

    [Space(20)]
    [SerializeField]
    private Transform[] _cannon;
    [SerializeField]
    private Transform _target;

    [Header("Shooting")]
    [SerializeField] 
    private float _timeBetweenBullets = 0.2f;
    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private Transform[] _shootPoints;

    private Vector3 _initPos, _endPos;
    private float _fireTimer = 0;
    
    protected void Start()
    {   
        _initPos = _initPosTransform.position;
        _endPos = _endPosTransform.position;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _fireTimer = _timeBetweenBullets;
        HealthPoints = TotalHealthPoints;
    }

    private void Update()
    {
        Move();
        LookAtTarget();
        TryToShoot();
    }

    private void Move()
    {
        float d = (_initPos - _endPos).magnitude;
        float delta = Mathf.PingPong(Time.time * _speed, d);
        transform.position = Vector3.Lerp(_initPos, _endPos, delta / d);
    }

    private void LookAtTarget()
    {
        if(!_target)
            return;
        
        foreach (Transform c in _cannon)
        {
            c.up = (_target.position - c.position).normalized;
        }
    }

    private void TryToShoot()
    {
        if(!_target)
            return;

        if (_fireTimer > 0)
            _fireTimer -= Time.deltaTime;

        if (_fireTimer <= 0)
        {
            _fireTimer = _timeBetweenBullets;
            Shoot();
        }
        
    }

    private void Shoot()
    {
        foreach (Transform s in _shootPoints)
        {
            GameObject projectile = Instantiate(_projectilePrefab);
            projectile.transform.position = s.position;
            projectile.transform.rotation = s.rotation;
        }
    }
    
    public void TakeHit()
    {
        if(HealthPoints <= 0)
            return;
    
        HealthPoints--;
        if(HealthPoints <= 0) {
            Instantiate(_deadVFXPrefab, GetComponent<Transform>().position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        if(!_initPosTransform || !_endPosTransform)
            return;
        
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_initPosTransform.position, 0.1f);
        Gizmos.DrawLine(_initPosTransform.position, _endPosTransform.position);
        Gizmos.DrawSphere(_endPosTransform.position, 0.1f);

        if (!Application.isPlaying)
        {
            Vector3 midPoint = (_initPosTransform.position + _endPosTransform.position) / 2;
            midPoint.z = 0;
            transform.position = midPoint;
        }
            
    }
}
