// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

namespace Utility
{
    public class CooldownTimer : ICooldownable
    {
        private bool _isOnCooldown;
        private MonoBehaviour _root;
        public CooldownTimer()
        {
            CheckRoot();
            _isOnCooldown = false;
        }

        public void BeginCooldown(float time)
        {
            CheckRoot();

            Assert.IsTrue(time > 0);

            _isOnCooldown = true;
            _root.StartCoroutine(Cooldown(time));
        }

        private void CheckRoot()
        {
            if (_root == null)
            {
               _root = Singletone<TimerRoot>.instance;
            }
        }

        public void EndCooldown()
        {
            CheckRoot();
            _root.StopCoroutine(nameof(Cooldown));
        }

        public bool IsOnCooldown()
        {
            return _isOnCooldown;
        }

        private IEnumerator Cooldown(float time)
        {
            yield return new WaitForSeconds(time);
            _isOnCooldown = false;
        }
    }
}