// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Core.Bullet.Movement;
using Core.Interfaces.Movement;
using Core.Interfaces.Spawner;
using Interfaces;
using Interfaces.Bullet;
using System;
using System.Collections;
using UnityEngine;
using Utility.Spawner;

namespace Core.Bullet
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : AbstractBullet
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        private ISpawner<AbstractBullet> _spawner;

        private IMovement _movement;
        private void Awake()
        {
            _movement = new BulletMovement(GetComponent<Rigidbody2D>());

            _spawner = Singletone<BulletSpawner>.instance;

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(1f);
                ReleasedSelf();
            }
        }
        public override void Setup(Vector2 position, Vector2 direction)
        {
            transform.position = position;

            Vector2 velocity = direction * _speed;

            _movement.Move(velocity);

            StartCoroutine(DestroySelfAfter(_lifeTime, ReleasedSelf));

        }
        private IEnumerator DestroySelfAfter(float destroyDeley, Action destroyAction)
        {
            yield return new WaitForSeconds(destroyDeley);

            destroyAction?.Invoke();
        }
        private void ReleasedSelf()
        {
            _spawner.Released(this);
        }
    }
}