// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using UnityEngine;

using Core.MVP.Player;
using Core.Interfaces.Movement;
using LocalPlayerStorage = Core.MVP.Storage.PlayerStorage;
using Core.Components;
using Interfaces;
using Interfaces.MVP.Player;

[RequireComponent(typeof(PlayerView), typeof(Rigidbody2D), typeof(LocalPlayerStorage))]
public class Player : MonoBehaviour
{
    private IPlayerPresenter _presenter;
    private IPlayerView _view;
    private IMovement _movement;
    private IPlayerStorage _storage;

    private void Awake()
    {

        _view = GetComponent<PlayerView>();
        _movement = new PlayerMovement(GetComponent<Rigidbody2D>());
        _storage = GetComponent<LocalPlayerStorage>();

        _presenter = new PlayerPresenter(_view, new PlayerModel(), _storage, _movement, GetComponent<PlayerAttackable>());
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if(_view is IDamageable damageable) 
            {
                damageable.TakeDamage(10);
                Debug.Log("Take Damage");
            }
        }
    }
    private void OnDestroy()
    {
        _presenter.Dispose();
    }
}
