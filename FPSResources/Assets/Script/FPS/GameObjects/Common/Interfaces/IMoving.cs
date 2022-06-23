using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoving
{
    void JumpTo(Rigidbody rb, Vector3 direction);
    void MoveTo(Rigidbody rb, Vector3 direction, float speed);
}
