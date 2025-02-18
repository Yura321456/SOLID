// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using System;
using UnityEngine;

namespace Core.MVP.Player
{

    public interface IPlayerStorage
    {
        public PlayerModelData Load();

        public void Save(PlayerModelData model);
    }

}