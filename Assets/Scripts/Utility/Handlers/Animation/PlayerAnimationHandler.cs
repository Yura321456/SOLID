// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Assertions;
using Utility.Enums;

namespace Utility.Handle
{
    public class PlayerAnimationHandler
    {
        private Animator _animator;

        public PlayerAnimationHandler(Animator animator)
        {
            _animator = animator;
        }

        private Dictionary<PlayerState, int> _animationIDs = new();
        private PlayerState _previousState = PlayerState.Idle;
        public void AddAnimation(PlayerState state, string animationName)
        {
            Assert.IsFalse(_animationIDs.ContainsKey(state), state + " is already used");

            _animationIDs[state] = Animator.StringToHash(animationName);
        }

        public void PlayAnimation(PlayerState state)
        {
            Assert.IsTrue(_animationIDs.TryGetValue(state, out int id));
            Assert.IsTrue(_animationIDs.TryGetValue(_previousState, out int previousID));

            _animator.ResetTrigger(previousID);
            _animator.SetTrigger(id);

            _previousState = state;
        }
    }
}
