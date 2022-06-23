using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputSystem
{
    event Action OnFire;
    event Action OnJumping;
    event Action<Vector3> OnMoving;
}
