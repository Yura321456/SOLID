// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using System;
using UnityEngine;
using UnityEngine.UIElements;

public interface IPlayerPresenter : IDisposable
{
    public void OnMove(Vector2 direction);
    public void OnShot();
}
