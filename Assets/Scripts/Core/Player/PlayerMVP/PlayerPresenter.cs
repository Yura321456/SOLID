// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Core.Interfaces.Movement;
using Interfaces.Attack;
using Interfaces.MVP.Player;
using UnityEngine;
using UnityEngine.Assertions;

namespace Core.MVP.Player
{
    public class PlayerPresenter : IPlayerPresenter
    {
        private IPlayerStorage _storage;
        private IPlayerModel _model;
        private IPlayerView _view;
        private IMovement _movement;
        private IAttackable _attackable;
        public PlayerPresenter(IPlayerView view, IPlayerModel model, IPlayerStorage storage, IMovement movement, IAttackable attackable)
        {
            Assert.IsNotNull(view);
            Assert.IsNotNull(storage);
            Assert.IsNotNull(movement);
            Assert.IsNotNull(attackable);

            _view = view;
            _storage = storage;
            _movement = movement;
            _attackable = attackable;
            _model = model;

            _model.Load(storage);

            _view.Shot += OnShot;
            _view.Moved += OnMove;
            _view.Damaged += OnTakeDamage;

            _view.PlayAnimation(_model.GetState());

        }
        public void OnMove(Vector2 direction)
        {
            if (_model.TryUpdateVelocity(direction))
            {
                _movement.Move(_model.GetVelocity());
                _view.PlayAnimation(_model.GetState());
            }
        }

        public void OnShot()
        {
            _attackable.Attack();
        }

        public void OnTakeDamage(float damage)
        {
           
        }

        public void Dispose()
        {
            _model.Save(_storage);

            _view.Damaged -= OnTakeDamage;
            _view.Shot -= OnShot;
            _view.Moved -= OnMove;
        }
    }
}


