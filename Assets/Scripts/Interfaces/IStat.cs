// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using UnityEngine;

namespace Interfaces.Stat
{
    public interface IStat
    {
        public float GetValue();
        public void Increase(float amount);
        public void Decrease(float amount);
    }
}
