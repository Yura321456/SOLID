// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Interfaces.Stat;
using System;
using UnityEngine;

namespace Utility.Stat
{
    [Serializable]
    public class Stat : IStat
    {
        private float _value;

        public Stat(float amount)
        {
            _value = Mathf.Clamp(amount, 0f, 999f);
        }
        public void Decrease(float amount)
        {
            _value = Mathf.Clamp(_value - amount, 0f, 999f);
        }

        public void Increase(float amount)
        {
            _value = Mathf.Clamp(_value + amount, 0f, 999f);
        }

        public float GetValue()
        {
            return _value;
        }
    }
}
