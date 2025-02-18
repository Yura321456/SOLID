// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Core.Interfaces.Spawner;
using Interfaces.Bullet;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;

namespace Utility.Spawner
{
    public class BulletSpawner : MonoBehaviour, ISpawner<AbstractBullet>
    {
        [SerializeField] private AbstractBullet _bulletPrefab;
        private ObjectPool<AbstractBullet> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<AbstractBullet>(
                createFunc: CreateBullet,
                actionOnGet: OnGet,
                actionOnRelease: OnReleased,
                actionOnDestroy: Destroy,
                collectionCheck: true,
                defaultCapacity: 10,
                maxSize: 20);
        }
        public void Released(AbstractBullet obj)
        {
            _pool.Release(obj);
        }

        public AbstractBullet Spawn()
        {
            return _pool.Get();
        }

        private void OnGet(AbstractBullet bullet)
        {
            bullet.Activate();
        }
        private void OnReleased(AbstractBullet bullet)
        {
            bullet.Deactivate();
        }
        private void Destroy(AbstractBullet bullet)
        {
            Destroy(bullet.gameObject);
        }
        private AbstractBullet CreateBullet()
        {
            return Instantiate(_bulletPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
