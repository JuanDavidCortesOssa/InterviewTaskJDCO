using System;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 _movement;

    public event Action<Vector2> MoveInput;

    private void OnMoveInput(Vector2 vector2)
    {
        MoveInput?.Invoke(vector2);
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        OnMoveInput(_movement.normalized);
    }
}