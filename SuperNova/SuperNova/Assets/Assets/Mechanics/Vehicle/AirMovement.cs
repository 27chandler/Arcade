using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMovement : PlayerInput, IControllable
{
    [SerializeField] private Rigidbody _balloonRb;
    [SerializeField] private float _thrust, _turnPower, _risePower, _descentStrength;

    private bool _areControlsLocked = true;

    void Start()
    {
        InputManager.Instance._onMove += Move;
        InputManager.Instance._onJumpHold += Rise;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onMove -= Move;
        InputManager.Instance._onJumpHold -= Rise;
    }

    void FixedUpdate()
    {
        _balloonRb.AddForce(-Vector3.up * _descentStrength * Time.deltaTime);
    }

    private void Move(Vector2 movement_direction)
    {
        if (!_areControlsLocked)
        {
            _balloonRb.AddForce(transform.forward * movement_direction.y * _thrust * Time.deltaTime);

            //_balloonRb.AddTorque(transform.up * movement_direction.x * _turnPower * Time.deltaTime);
            _balloonRb.rotation = Quaternion.Euler(new Vector3(0.0f, _balloonRb.rotation.eulerAngles.y + (movement_direction.x * _turnPower * Time.deltaTime), 0.0f));
        }
    }

    private void Rise()
    {
        if (!_areControlsLocked)
        {
            _balloonRb.AddForce(Vector3.up * _risePower * Time.deltaTime);
        }
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
