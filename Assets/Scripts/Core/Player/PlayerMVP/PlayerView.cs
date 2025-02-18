// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Core.Input.Handler;
using Core.MVP.Storage;
using Interfaces;
using Interfaces.MVP.Player;
using Core;
using UnityEngine;
using UnityEngine.Assertions;
using Utility.Enums;
using Utility.Handle;
using Core.Components;

namespace Core.MVP.Player
{
    [RequireComponent(typeof(PlayerAttackable))]
    public class PlayerView : MonoBehaviour, IPlayerView, IDamageable
    {
        [Header("Animations")]
        [SerializeField] private Animator _animator;
        [SerializeField] private string _idleAnimation;
        [SerializeField] private string _moveAnimation;
        [SerializeField] private string _fireAnimation;

        private PlayerInputHandler _inputHandler;
        private PlayerAnimationHandler _animationHandler;

        public event Action Shot;
        public event Action<float> Damaged;
        public event Action<Vector2> Moved;

        private void Awake()
        {

            _inputHandler = Singletone<PlayerInputHandler>.instance;

            Assert.IsNotNull(_inputHandler, "Input handle doe's not assigned");

            _animationHandler = new PlayerAnimationHandler(_animator);

            _animationHandler.AddAnimation(PlayerState.Idle, _idleAnimation);
            _animationHandler.AddAnimation(PlayerState.Move, _moveAnimation);
            _animationHandler.AddAnimation(PlayerState.Fire, _fireAnimation);

        }

        public void FixedUpdate()
        {
            OnMoved(_inputHandler.GetDirection());

            _inputHandler.Handle(_inputHandler.IsShotPressed, OnShot);
        }

        public void PlayAnimation(PlayerState playerState)
        {
            _animationHandler.PlayAnimation(playerState);
        }

        private void OnShot()
        {
            Shot?.Invoke();
        }

        private void OnMoved(Vector2 direction)
        {
            Moved?.Invoke(direction);
        }

        public void TakeDamage(float damage)
        {
            Damaged?.Invoke(damage);
        }

    }
}

