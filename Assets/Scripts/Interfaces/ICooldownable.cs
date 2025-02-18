// Copyright (c) [2024] [TeamLevel274]
// Усі права захищені.
//
// Цей код є власністю [TeamLevel274] і не може бути використаний без дозволу.

using UnityEngine;

public interface ICooldownable
{
    public void BeginCooldown(float time);
    public bool IsOnCooldown();
    public void EndCooldown();
}
