// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Unity.Plastic.Newtonsoft.Json.Bson;
using UnityEngine;
using UnityEngine.Assertions;

namespace Utility.Move
{
    public class TranslateMove
    {
        private float _speed;
        public TranslateMove(float speed)
        {
            _speed = speed;
        }

        public void Move(Vector3 direction, Transform mover, float velocityMultiply = 1) 
        {
            Assert.IsNotNull(mover);

            mover.Translate(_speed * velocityMultiply * direction);
        }
    }
}
