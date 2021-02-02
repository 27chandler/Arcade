using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : PlayerInput, IControllable
{
    [SerializeField] private float _acceleration;
    [SerializeField] private float _turnSpeed;

    private bool _areControlsLocked = true;

    [SerializeField] private Rigidbody _carRb;

    void Start()
    {
        _carRb.transform.parent = null;

        InputManager.Instance._onMove += Move;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onMove -= Move;
    }

    private void Update()
    {
        transform.position = _carRb.transform.position;
    }

    private void Move(Vector2 movement_direction)
    {
        if (!_areControlsLocked)
        {
            _carRb.AddForce(transform.forward * movement_direction.y * _acceleration * Time.deltaTime);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0.0f, movement_direction.x * _turnSpeed * Time.deltaTime, 0.0f));
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
