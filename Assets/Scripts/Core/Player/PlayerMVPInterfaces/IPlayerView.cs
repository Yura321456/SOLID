// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Utility.Enums;



namespace Interfaces.MVP.Player
{
    public interface IPlayerView
    {
        public event Action<Vector2> Moved;
        public event Action<float> Damaged;
        public event Action Shot;
        public void PlayAnimation(PlayerState playerState);
    }
}
