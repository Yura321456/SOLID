// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using System;
using UnityEngine;
using Utility.Stat;

[CreateAssetMenu(fileName = "PlayerScriptableModel", menuName = "PlayerScriptableModel")]
public class PlayerModelScriptable : ScriptableObject
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;

    public float moveSpeed { get => _moveSpeed; }
    public float maxHealth { get => _maxHealth; }
    public float health { get => _health; }

    public PlayerModelScriptable Copy(PlayerModelData data)
    {
        _moveSpeed = data.moveSpeed.GetValue();
        _maxHealth = data.maxHealth.GetValue();
        _health = data.health.GetValue();

        return this;
    }

    public PlayerModelScriptable Copy(PlayerModelScriptable data)
    {
        _moveSpeed = data.moveSpeed;
        _maxHealth = data.maxHealth;
        _health = data.health;

        return this;
    }
}

public struct PlayerModelData
{
    public Stat moveSpeed { get; private set; }
    public Stat maxHealth { get; private set; }
    public Stat health { get; private set; }

#if DEBUG
    public void Initialize(float moveSpeed, float maxHealth, float health)
    {
        this.moveSpeed = new Stat(moveSpeed);
        this.maxHealth = new Stat(maxHealth);
        this.health = new Stat(health);
    }
#endif
    public PlayerModelData Copy(PlayerModelData data)
    {
        moveSpeed = new Stat(data.moveSpeed.GetValue());
        maxHealth = new Stat(data.maxHealth.GetValue());
        health = new Stat(data.health.GetValue());

        return this;
    }

    public PlayerModelData Copy(PlayerModelScriptable data)
    {
        moveSpeed = new Stat(data.moveSpeed);
        maxHealth = new Stat(data.maxHealth);
        health = new Stat(data.health);

        return this;
    }
}