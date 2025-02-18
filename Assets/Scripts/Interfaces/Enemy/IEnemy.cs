// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using UnityEngine;

namespace Interfaces.Enemy
{
    public interface IEnemy : IDamageable
    {
        public void Attack();
        public void Move();
        public void Die();
    }
}