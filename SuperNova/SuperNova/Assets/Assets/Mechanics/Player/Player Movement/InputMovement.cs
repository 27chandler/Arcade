using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour, IControllable
{
    [SerializeField] private float _movementSpeed = 1.0f;
    [SerializeField] private CharacterController _controller;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance;
    [SerializeField] private LayerMask _groundMask;

    [SerializeField] private float _speed = 12.0f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpheight = 3.0f;

    private Vector3 _velocity;
    private bool _isGrounded;

    private bool _areControlsLocked = false;

    void Start()
    {
        InputManager.Instance._onJump += Jump;
        InputManager.Instance._onMove += Move;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onJump -= Jump;
        InputManager.Instance._onMove -= Move;
    }

    void FixedUpdate()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (_isGrounded && _velocity.y < 0.0f)
        {
            _velocity.y = -2.0f;
        }

        _velocity.y += _gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
    }

    private void Move(Vector2 movement_direction)
    {
        if (!_areControlsLocked)
        {
            // The change in position this frame
            Vector3 position_delta = new Vector3();
            position_delta += (transform.right * Input.GetAxis("Horizontal")) * _movementSpeed * Time.deltaTime;
            position_delta += (transform.forward * Input.GetAxis("Vertical")) * _movementSpeed * Time.deltaTime;

            _controller.Move(position_delta);
        }
    }

    private void Jump()
    {
        if (_isGrounded && !_areControlsLocked)
            _velocity.y += Mathf.Sqrt(_jumpheight * -2.0f * _gravity);
    }

    void IControllable.FreezeControls()
    {
        _areControlsLocked = true;
    }

    void IControllable.UnFreezeControls()
    {
        _areControlsLocked = false;
    }
}
