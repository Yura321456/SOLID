// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Core.Input.Handler
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerInputActions _actions;

        private void Awake()
        {
            _actions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _actions.Enable();
        }
        private void OnDisable()
        {
            _actions.Disable();
        }

        public Vector2 GetDirection()
        {
            return _actions.Player.Move.ReadValue<Vector2>();
        }

        public bool IsShotPressed()
        {
            return _actions.Player.Fire.IsPressed();
        }

        public void Handle(Func<bool> inputPredicate, Action reply) 
        {
            Assert.IsNotNull(inputPredicate);
            Assert.IsNotNull(reply);

            if(inputPredicate.Invoke())
            {
                reply();
            }
        }
    }
}