
// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Interfaces.Stat;
using System;
using UnityEngine;
using UnityEngine.Assertions;
using Utility.Enums;

namespace Core.MVP.Player
{
    public class PlayerModel : IPlayerModel
    {
        private PlayerModelData _data;

        private Vector2 _velocity;

        private PlayerState _state;

        public PlayerModel()
        {
            _state = PlayerState.Idle;
            _velocity = Vector2.zero;
        }

        public bool TryUpdateVelocity(Vector2 direction, Action<Vector2, float> velocityCalculator = null)
        {

            var previousVelocity = _velocity;
            velocityCalculator ??= BaseVelocityCalculator;

            velocityCalculator.Invoke(direction, GetSpeed());
           
            _state = GetMovementState();

            return previousVelocity != _velocity;
        }
        public void Load(IPlayerStorage storage)
        {
            Assert.IsNotNull(storage);

            _data = storage.Load();
        }

        public void Save(IPlayerStorage storage)
        {
            Assert.IsNotNull(storage);

            storage.Save(_data);
        }
        public void TakeDamage(float damage)
        {
            _data.health.Decrease(damage);
        }

        public Vector2 GetVelocity()
        {
            return _velocity;
        }

        public PlayerState GetState()
        {
            return _state;
        }

        public float GetSpeed()
        {
            Assert.IsNotNull(_data.moveSpeed,"moveSpeed field is null");

            return _data.moveSpeed.GetValue();
        }

        public float GetHealth()
        {
            Assert.IsNotNull(_data.health, "health field is null");

            return _data.health.GetValue();
        }
        private void BaseVelocityCalculator(Vector2 direction, float speed)
        {
            _velocity = direction * speed;
        }

        private PlayerState GetMovementState()
        {
            return _velocity == Vector2.zero ? PlayerState.Idle : PlayerState.Move;
        }

    }
}
