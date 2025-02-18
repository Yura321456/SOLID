// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Core.MVP.Player;
using NUnit.Framework;
using Interfaces.Attack;
using Core.Interfaces.Movement;
using System;
using NSubstitute;
using UnityEngine;
using Interfaces.MVP.Player;
using System.Runtime.InteropServices;

[TestFixture]
public class PlayerTests
{

    private IPlayerPresenter _presenter;
    private IPlayerModel _model;
    private IAttackable _attackable;
    private IPlayerView _mockView;
    private IPlayerStorage _storage;
    private IMovement _movement;

    [SetUp]
    public void Setup()
    {
        _model = new PlayerModel();
        _attackable = Substitute.For<IAttackable>();
        _mockView = Substitute.For<IPlayerView>();
        _storage = Substitute.For<IPlayerStorage>();
        _movement = Substitute.For<IMovement>();

        _presenter = new PlayerPresenter(_mockView, _model, _storage, _movement, _attackable);

    }

    [Test]
    public void MovePlayerShouldUpdateVelocity()
    {

        var modelData = new PlayerModelData();

        modelData.Initialize(5f, 100f, 0f);

        _storage.Load().Returns(returnThis: modelData);

        _model.Load(_storage);

        Assert.AreEqual(_model.GetVelocity(), Vector2.zero);

        _model.TryUpdateVelocity(new Vector2(0, 1));
        Debug.Log(_model.GetVelocity());

        Assert.AreEqual(_model.GetVelocity(), new Vector2(0, 1 * _model.GetSpeed()));

    }

    [Test]
    public void ChangeAttrubutesShouldBeSaved()
    {
        var modelData = new PlayerModelData();
        _storage = Substitute.For<IPlayerStorage>();

        modelData.Initialize(5f, 100f, 100f);

        _storage.Load().Returns(modelData);
        _storage.When((x) => x.Save(Arg.Any<PlayerModelData>())).Do((callInfo) => Debug.Log("Saved health is " + callInfo.Arg<PlayerModelData>().health.GetValue()));


        _model.Load(_storage);
        _model.TakeDamage(50f);
        _model.Save(_storage);


        _storage.Received(1).Load();
        _storage.Received(1).Save(Arg.Is<PlayerModelData>(data =>
            data.health.GetValue() == 50f
        ));
    }
    [Test]
    public void PlayerAttacksWhenInputPressed()
    {
        _attackable.When((attackable) => attackable.Attack()).Do(_ => Debug.Log("Attack"));
        _presenter.When((presenter) => presenter.OnShot()).Do(_ => _attackable.Attack());

        _mockView.Shot += _presenter.OnShot;
        _mockView.Shot += Raise.Event<Action>();

        _presenter.Received(1).OnShot();
        _attackable.Received(1).Attack();
    }
}
