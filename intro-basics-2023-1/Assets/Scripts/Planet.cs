using UnityEngine;

namespace IntroGames.Planets
{

    public class Planet : MonoBehaviour
    {

        [Header("Movement")] [SerializeField] private float _movementSpeed = 30f; // degrees/sec
        [SerializeField] private float _radius = 20f;

        [Header("Rotation")] [SerializeField] private float _localRotationSpeed; // degrees/sec

        [Space(20)] [SerializeField] private Transform _center;

        private float _angleMovementRad; //rad

        void Update()
        {
            _angleMovementRad += _movementSpeed * Mathf.Deg2Rad * Time.deltaTime;

            //Movement
            //RotateAround();
            CircleMovement();

            //Rotation
            //IndependentRotation();
            LookAtCenter();
        }

        void RotateAround()
        {
            transform.RotateAround(_center.position, Vector3.forward, _movementSpeed * Time.deltaTime);
        }

        void CircleMovement()
        {
            var offset = new Vector2(Mathf.Sin(_angleMovementRad), Mathf.Cos(_angleMovementRad)) * _radius;
            transform.position = _center.position + (Vector3)offset;
        }

        void IndependentRotation()
        {
            transform.Rotate(Vector3.forward, _localRotationSpeed * Time.deltaTime);
        }

        void LookAtCenter()
        {
            Vector3 aimVector = (_center.position - transform.position).normalized; //Direction
            float lookAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg - 90;

            Vector3 rot = transform.eulerAngles;
            rot.z = lookAngle;
            transform.eulerAngles = rot;
        }
    }
}
