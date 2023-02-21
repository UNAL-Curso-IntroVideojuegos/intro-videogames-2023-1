using UnityEngine;

namespace IntroGames.Planets
{
    public class PlayerShip : MonoBehaviour
    {

        [SerializeField] private float _rotationSpeed = 45; // degrees/sec
        [SerializeField] private float _acceleration = 3f;
        [SerializeField] private float _desacceleration = 1f;
        [SerializeField] private float _maxSpeed = 1.6f;

        private Quaternion _targetBodyRot;
        private float _speed;

        void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector2 dir = new Vector2(horizontal, vertical).normalized;

            if (dir.sqrMagnitude > 0)
            {
                float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
                _targetBodyRot = Quaternion.Euler(0, 0, targetAngle);
                _speed += _acceleration * Time.deltaTime;
            }
            else
            {
                _speed -= _desacceleration * Time.deltaTime;

            }

            _speed = Mathf.Clamp(_speed, 0, _maxSpeed);

            transform.position += transform.up * _speed * Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, _targetBodyRot,
                _rotationSpeed * Mathf.Deg2Rad * Time.deltaTime);
        }
    }
}