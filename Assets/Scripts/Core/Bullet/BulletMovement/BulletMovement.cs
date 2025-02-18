// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Core.Interfaces.Movement;
using UnityEngine;


namespace Core.Bullet.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletMovement : IMovement
    {
        private Rigidbody2D _rigidBody;

        public BulletMovement(Rigidbody2D rigidbody)
        {
            _rigidBody = rigidbody;
        }

        public void Move(Vector2 velocity)
        {
            _rigidBody.velocity = velocity;
        }
    }
}