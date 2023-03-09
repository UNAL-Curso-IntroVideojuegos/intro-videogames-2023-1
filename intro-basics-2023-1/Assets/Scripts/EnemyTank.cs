using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [Space(20)]
    [SerializeField]
    private float _speed = 1;

    [Space(20)]
    [SerializeField]
    private Transform _initPos;
    [SerializeField]
    private Transform _endPos;

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

    private float _fireTimer = 0;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        HealthPoints = TotalHealthPoints;
        _fireTimer = _timeBetweenBullets;
    }

    private void Update()
    {
        Move();
        LookAtTarget();
        TryToShoot();
    }

    private void Move()
    {
        float d = (_initPos.position - _endPos.position).magnitude;
        float delta = Mathf.PingPong(Time.time * _speed, d);
        transform.position = Vector3.Lerp(_initPos.position, _endPos.position, delta / d);
    }

    private void LookAtTarget()
    {
        if (!_target)
            return;

        foreach (Transform c in _cannon)
        {
            c.up = (c.position -_target.position  ).normalized;
        }
    }

    private void TryToShoot()
    {
        if (!_target)
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
        if (HealthPoints <= 0)
            return;

        HealthPoints--;
        if (HealthPoints <= 0)
            gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        if (!_initPos || !_endPos)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_initPos.position, 0.1f);
        Gizmos.DrawLine(_initPos.position, _endPos.position);
        Gizmos.DrawSphere(_endPos.position, 0.1f);

        if (!Application.isPlaying)
        {
            Vector3 midPoint = (_initPos.position + _endPos.position) / 2;
            midPoint.z = 0;
            transform.position = midPoint;
        }

    }
}
