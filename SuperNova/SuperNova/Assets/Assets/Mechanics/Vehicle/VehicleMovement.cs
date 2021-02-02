using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : PlayerInput, IControllable
{
    [SerializeField] private float _acceleration;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _groundCheckDistance;
    [SerializeField] private float _inAirDrag;

    [SerializeField] private Rigidbody _carRb;
    [SerializeField] private Transform _groundCheck;

    private bool _areControlsLocked = true;
    private bool _isGrounded = false;

    private float _defaultDrag;

    void Start()
    {
        _carRb.transform.parent = null;
        _defaultDrag = _carRb.drag;

        InputManager.Instance._onMove += Move;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onMove -= Move;
    }

    private void Update()
    {
        GroundCheck();

        transform.position = _carRb.transform.position;
    }

    private void Move(Vector2 movement_direction)
    {
        if (!_areControlsLocked && _isGrounded)
        {
            _carRb.AddForce(transform.forward * movement_direction.y * _acceleration * Time.deltaTime);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0.0f, movement_direction.x * _turnSpeed * Time.deltaTime, 0.0f));
        }
    }

    private void GroundCheck()
    {
        RaycastHit hit;
        Physics.Raycast(_groundCheck.position, Vector3.down,out hit, _groundCheckDistance);

        if (hit.collider != null)
        {
            _isGrounded = true;

            _carRb.drag = _defaultDrag;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        else
        {
            _isGrounded = false;

            _carRb.drag = _inAirDrag;
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
