using System;
using UnityEngine;

namespace Projectile
{
    public class ProjectileMotion : MonoBehaviour
    {
        public event Action ProjectileDestroyed;
        public event Action<RaycastHit> OnCollisionDetected;
        
        private readonly float _wallBounceMultiplier = 0.03f;
        private readonly float _defaultBounceMultiplier = 0.5f;
        private readonly float _backOffset = 0.2f;
        private Vector3 _velocity;
        private Vector3 _startPosition;
        private float _flightDuration;
        private int _impactsCount;

        public void Init(Vector3 launchVelocity)
        {
            _velocity = launchVelocity;
            _startPosition = transform.position;
            _flightDuration = 0;
            _impactsCount = 0;
        }

        private void FixedUpdate()
        {
            _flightDuration += Time.fixedDeltaTime;
            DetectCollisions();
            UpdatePosition();
            ApplyGravity();
        }

        private void DetectCollisions()
        {
            float movementStep = _velocity.magnitude * Time.fixedDeltaTime;
            Vector3 movementDirection = _velocity.normalized;
            RaycastHit hitInfo;

            if (Physics.Raycast(_startPosition, movementDirection, out hitInfo, movementStep))
            {
                ResolveCollision(hitInfo);
            }
        }

        private void ResolveCollision(RaycastHit hitInfo)
        {
            OnCollisionDetected?.Invoke(hitInfo);
            Vector3 backDirection = -_velocity.normalized * _backOffset;
            _startPosition = hitInfo.point + backDirection;
            _impactsCount++;

            if (_impactsCount >= 2)
            {
                ProjectileDestroyed?.Invoke();
                gameObject.SetActive(false);
            }
            else
            {
                _velocity = Vector3.Reflect(_velocity, hitInfo.normal);
                _velocity *= hitInfo.collider.CompareTag(Constants.Constants.WAll_1_TAG) ? _wallBounceMultiplier : _defaultBounceMultiplier;
                _flightDuration = 0;
            }
        }

        private void UpdatePosition()
        {
            Vector3 displacement = _velocity * Time.fixedDeltaTime;
            _startPosition += displacement;
            transform.position = _startPosition;
        }

        private void ApplyGravity()
        {
            _velocity += Vector3.up * (Constants.Constants.PHYSICS_GRAVITY_Y * Time.fixedDeltaTime);
        }
    }
}