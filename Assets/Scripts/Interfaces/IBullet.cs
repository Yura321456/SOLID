// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using UnityEngine;

namespace Interfaces.Bullet
{
    public abstract class AbstractBullet : MonoBehaviour
    {
        public abstract void Setup(Vector2 position, Vector2 direction);

        public virtual void Activate() 
        {
            gameObject.SetActive(true);
        }

        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}