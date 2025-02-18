// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Core.Interfaces.Movement;
using UnityEngine;

namespace Core.Components
{
    public class PlayerMovement : IMovement
    {
        private Rigidbody2D _rigidBody;
        public PlayerMovement(Rigidbody2D rigidBody)
        {
            _rigidBody = rigidBody;
        }

        public void Move(Vector2 velocity)
        {
            _rigidBody.velocity = velocity;
        }
    }
}