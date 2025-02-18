// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Codice.CM.Common;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Utility
{
    public class EyesTracker : MonoBehaviour
    {
        [SerializeField] private Trackable _target;
        [SerializeField] private float _radius;

        private Vector3 _basePosition;
        private void Awake()
        {
            SetOrThrowIfNoTarget();

            _basePosition = transform.localPosition;
        }

        private void SetOrThrowIfNoTarget()
        {
            if (_target == null)
            {
                Debug.LogWarning("Target is not setted");
                _target = FindAnyObjectByType<Trackable>();
            }
            if (_target == null)
                throw new ArgumentNullException("Instance of trackable is not exist");
        }

        private void FixedUpdate()
        {
            TrackAt(_target.transform.position, _radius);
        }

        private void TrackAt(Vector3 targetPosition, float radius)
        {
            Vector3 distance = targetPosition - transform.position;

            Vector3 deltaPosition = Vector3.ClampMagnitude(distance, radius);

            transform.localPosition = _basePosition + deltaPosition;
        }

    }

}