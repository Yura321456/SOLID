// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Core.Interfaces.Spawner;
using Interfaces.Attack;
using Interfaces.Bullet;
using System.Collections;
using UnityEngine;
using Utility;
using Utility.Spawner;

namespace Core.Components
{
    public class PlayerAttackable : MonoBehaviour, IAttackable
    {
        [Header("Attack Properties")]
        [SerializeField] private float _attackCooldown;
        [SerializeField] private int _countOfBullet;
        [SerializeField] private float _delayBeetwinSpawnBullet;

        [Header("Bullet Setup")]
        [SerializeField] private Transform _bulletSpawnPoint;

        private ISpawner<AbstractBullet> _bulletSpawner;
        private ICooldownable _cooldownable;

        private void Awake()
        {
            _bulletSpawner = Singletone<BulletSpawner>.instance;

            _cooldownable = new CooldownTimer();
        }
        public void Attack()
        {
            if (_cooldownable.IsOnCooldown() == false)
            {
                SpawnBullets();
                _cooldownable.BeginCooldown(_attackCooldown);
            }
        }

        private void SpawnBullets()
        {
            if (_delayBeetwinSpawnBullet == 0)
                SpawnInstantly();
            else
                SpawnWithDelay();

        }
        private void SpawnWithDelay()
        {
            StartCoroutine(BeginSpawningBullet());
        }

        private void SpawnInstantly()
        {
            for (int i = 0; i < _countOfBullet; i++)
            {
                SpawnBullet();
            }
        }
        private IEnumerator BeginSpawningBullet()
        {
            for (int i = 0; i < _countOfBullet; i++)
            {
                SpawnBullet();
                yield return new WaitForSeconds(_delayBeetwinSpawnBullet);
            }
        }

        private void SpawnBullet()
        {
            var bullet = _bulletSpawner.Spawn();
            bullet.Setup(_bulletSpawnPoint.position, Vector2.up);
        }
    }
}