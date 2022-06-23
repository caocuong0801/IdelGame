using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerComponent
{
    event Action OnFired;
    event Action OnJumped;
    event Action<Vector3> OnMovingDirectionChanged;

    string Id { get; set; }
    IStatsComponent Stats { get; set; }

    void Jump();
    void Fire();
    void Move(Vector3 direction);
}
