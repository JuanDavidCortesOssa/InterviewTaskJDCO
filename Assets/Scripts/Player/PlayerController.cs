using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject playerVisuals;
    [SerializeField] private Animator animator;

    private PlayerInputHandler _playerInputHandler;
    private Rigidbody2D _rb;
    private bool _isFacingRight = true;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Start()
    {
        InitializeVariables();
        AddListeners();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    private void InitializeVariables()
    {
        _playerInputHandler = GetComponent<PlayerInputHandler>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void AddListeners()
    {
        _playerInputHandler.MoveInput += Move;
    }

    private void RemoveListeners()
    {
        _playerInputHandler.MoveInput -= Move;
    }

    private void Move(Vector2 movement)
    {
        _rb.MovePosition(_rb.position + movement * (speed * Time.fixedDeltaTime));
        RotateCharacter(movement.x);
        animator.SetFloat(Speed, movement.sqrMagnitude);
    }

    private void RotateCharacter(float axis)
    {
        switch (axis)
        {
            case < 0 when _isFacingRight:
                playerVisuals.transform.localScale = new Vector3(-1, 1, 1);
                _isFacingRight = false;
                break;
            case > 0 when !_isFacingRight:
                playerVisuals.transform.localScale = new Vector3(1, 1, 1);
                _isFacingRight = true;
                break;
        }
    }
}