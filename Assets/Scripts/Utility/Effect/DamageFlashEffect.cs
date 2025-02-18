// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using System.Collections;
using UnityEngine;

public class DamageFlashEffect 
{
    private float _flashTimer;
    private float _flashDuration;
    private float _flashDelay;

    private SpriteRenderer _renderer;

    private Color _previousColor;
    private Color _normalColor;
    private Color _flashColor;


    public DamageFlashEffect(Color normalColor,Color onTakeDamageColor, SpriteRenderer spriteRenderer, float flashTime, float flashDelay = 0) 
    {
        _normalColor = normalColor;
        _previousColor = normalColor;
        _flashColor = onTakeDamageColor;
        
        _renderer = spriteRenderer; 
        
        _flashDelay = flashDelay;
        
        _flashDuration = flashTime;
        _flashTimer = flashTime;

    }

    public IEnumerator FlashEffect()
    {
        while (_flashDuration > 0f)
        {
            ToggleColor();
            yield return new WaitForSeconds(_flashDelay);
            _flashDuration -= _flashDelay;

        }
        _flashDuration = _flashTimer;
        ResetColor();
    }

    private void ResetColor()
    {
        if (_previousColor == _normalColor)
            ToggleColor();
    }

    public void ToggleColor()
    {
        _previousColor = _renderer.color;
        _renderer.color = _previousColor == _normalColor ? _flashColor : _normalColor;

        Debug.Log(_renderer.color);
    }
}
