// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using Codice.Utils;
using Interfaces.Enemy;
using System.Collections;
using UnityEngine;
using Utility;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private Color _onTakeDamageColor;
    [SerializeField] private float _changeColorDelay;
    [SerializeField] private float _changeColorTime;

    private DamageFlashEffect _flashEffect;
    private void Awake()
    {
        var renderer = GetComponent<SpriteRenderer>();
        _flashEffect = new DamageFlashEffect(renderer.color, _onTakeDamageColor, renderer, _changeColorTime, _changeColorDelay);
    }
    public void Attack()
    {

    }

    public void Die()
    {

    }

    public void Move()
    {
    }

    public void TakeDamage(float damage)
    {
        TakeDamageVFX();
    }

    public void TakeDamageVFX()
    {
        StopCoroutine(_flashEffect.FlashEffect());
        StartCoroutine(_flashEffect.FlashEffect());
    }
}
