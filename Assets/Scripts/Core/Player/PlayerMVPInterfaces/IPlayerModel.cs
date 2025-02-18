// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Interfaces.Stat;
using System;
using UnityEngine;
using Utility.Enums;

namespace Core.MVP.Player
{
    public interface IPlayerModel
    {
        public bool TryUpdateVelocity(Vector2 direction, Action<Vector2,float> velocityCalcutator = null);

        public Vector2 GetVelocity();
        public PlayerState GetState();
        public float GetSpeed();
        public float GetHealth();
        public void TakeDamage(float damage);
        public void Load(IPlayerStorage storage);
        public void Save(IPlayerStorage storage);
    }
}