using System;
using UnityEngine;

namespace IntroGames.Planets
{

    public class Planet : MonoBehaviour
    {

        [Header("Movement")] 
        [SerializeField] private float _movementSpeed = 30f; // degrees/sec
        [SerializeField] private float _radius = 20f;

        [Header("Rotation")]
        [SerializeField] private float _localRotationSpeed; // degrees/sec

        [Space(20)]
        [SerializeField] private Transform _center;

        private float _angleMovementRad; //rad
        
        //Trail VFX
        private TrailRenderer _trailRenderer;
        private float _trailDelay = 0.1f; // delay to enable the trail

        private void Start()
        {
            _trailRenderer = GetComponentInChildren<TrailRenderer>();
        }

        void Update()
        {
            _angleMovementRad += _movementSpeed * Mathf.Deg2Rad * Time.deltaTime;

            //Movement
            //RotateAround();
            CircleMovement();

            //Own Rotation
            //IndependentRotation();
            LookAtCenter();

            //Trail VFX
            UpdateTrailTime();
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
        
        void UpdateTrailTime()
        {
            //If null -> return
            if(!_trailRenderer)
                return;
            
            if (_trailDelay > 0f)
            {
                _trailDelay -= Time.deltaTime;
                _trailRenderer.time = 0;
            }
            else
            {
                _trailRenderer.time = 360f / _movementSpeed; //T = X/V
            }
        }
    }
}
