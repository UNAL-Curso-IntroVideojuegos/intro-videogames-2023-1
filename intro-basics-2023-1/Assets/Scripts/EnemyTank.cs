using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
  [SerializeField]
  private float _speed = 1;
  [SerializeField]
  private Transform[] _cannons;

  [SerializeField]
  private Transform[] _shootPoints;

  [SerializeField]
  private GameObject _projectilePrefab;

  [SerializeField]
  private Transform _target;

  private Rigidbody2D _rb;
  private float _dirY;

  private float _shootingTime = 0;




  private void Start()
  {
    gameObject.SetActive(false);
    _rb = GetComponent<Rigidbody2D>();
    _dirY = 1f;

  }

  void Update()
  {
    Vector3 targetPosition = _target.position;
    targetPosition.z = 0;
    for (int i = 0; i < _cannons.Length; i++)
    {
      Vector3 aimVector = (targetPosition - _cannons[i].position).normalized;
      float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg + 90;
      _cannons[i].rotation = Quaternion.Euler(0, 0, angle);
    }

    if (_shootingTime > 0)
    {
      _shootingTime -= Time.deltaTime;
    }
    else
    {
      _shootingTime = 3;

      for (int i = 0; i < _shootPoints.Length; i++)
      {
        //Shoot
        GameObject projectile = Instantiate(_projectilePrefab);
        projectile.transform.position = _shootPoints[i].position;
        projectile.transform.rotation = _shootPoints[i].rotation;
      }
    }

  }

  private void FixedUpdate()
  {
    _rb.velocity = new Vector2(_rb.velocity.x, _dirY * _speed);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.GetComponent<SwitchPoint>())
    {
      _dirY *= -1;
    }
  }
}
