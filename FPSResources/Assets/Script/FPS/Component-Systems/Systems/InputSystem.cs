using System;
using UnityEngine;

public class InputSystem : MonoBehaviour, IInputSystem
{
    private const int KEY_FIRE = 0;
    private const KeyCode KEY_JUMP = KeyCode.Space;
    private const KeyCode KEY_MOVE_BACK = KeyCode.S;
    private const KeyCode KEY_MOVE_FORWARD = KeyCode.W;
    private const KeyCode KEY_MOVE_LEFT = KeyCode.A;
    private const KeyCode KEY_MOVE_RIGHT = KeyCode.D;

    public event Action OnFire;
    public event Action OnJumping;
    public event Action<Vector3> OnMoving;

    void FixedUpdate()
    {
        var directionX = 0f;
        var directionY = 0f;
        if (Input.GetKey(KEY_MOVE_LEFT))
        {
            directionX = Vector2.left.x;
        }
        if (Input.GetKey(KEY_MOVE_RIGHT))
        {
            directionX = Vector2.right.x;
        }
        if (Input.GetKey(KEY_MOVE_FORWARD))
        {
            directionY = Vector2.up.y;
        }
        if (Input.GetKey(KEY_MOVE_BACK))
        {
            directionY = Vector2.down.y;
        }
        if (directionX != 0f || directionY != 0f)
        {
            OnMoving?.Invoke(new Vector3(directionX, 0, directionY));
        }

        if (Input.GetMouseButtonDown(KEY_FIRE))
        {
            OnFire?.Invoke();
        }

        if (Input.GetKeyDown(KEY_JUMP))
        {
            OnJumping?.Invoke();
        }
    }
}
