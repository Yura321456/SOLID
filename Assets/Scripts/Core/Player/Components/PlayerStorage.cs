// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Core.MVP.Player;
using UnityEngine;

namespace Core.MVP.Storage
{
    public class PlayerStorage : MonoBehaviour, IPlayerStorage
    {
        [SerializeField] private PlayerModelScriptable _basePlayerData;
        [SerializeField] private PlayerModelScriptable _mutablePlayerData;
        [Header("Debug Tool")][SerializeField] private bool _reloadOnGameStartPlayerData;
        public PlayerModelData Load()
        {
            if (_reloadOnGameStartPlayerData == true)
                _mutablePlayerData.Copy(_basePlayerData);


            return new PlayerModelData().Copy(_mutablePlayerData);
        }

        public void Save(PlayerModelData data)
        {
            _mutablePlayerData.Copy(data);
        }
    }
}
