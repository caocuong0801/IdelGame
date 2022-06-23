using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerComponent : IPlayerComponent
{
    public event Action OnFired;
    public event Action OnJumped;
    public event Action<Vector3> OnMovingDirectionChanged;

    public string Id { get; set; }

    public IStatsComponent Stats { get; set; }

    [Inject]
    public PlayerComponent(IStatsComponent _stats)
    {
        Stats = _stats;
    }

    public void Jump()
    {
        OnJumped?.Invoke();
    }

    public void Fire()
    {
        OnFired?.Invoke();
    }

    public void Move(Vector3 direction)
    {
        OnMovingDirectionChanged?.Invoke(direction);
    }
}
