// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using UnityEngine;

namespace Core.Interfaces.Spawner
{
    public interface ISpawner<T>
    {
        public T Spawn();
        public void Released(T obj);
    }
}
