using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Moving : IMoving
{
    public void MoveTo(Rigidbody rb, Vector3 direction, float speed)
    {
        if (rb == null) return;

        direction = rb.rotation * direction;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    public void JumpTo(Rigidbody rb, Vector3 direction)
    {
        if (rb == null) return;
        rb.AddForce(direction, ForceMode.Impulse);
    }
}
