using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongControls : PlayerInput, IControllable
{
    [SerializeField] private bool _areControlsLocked;

    void Start()
    {
        InputManager.Instance._onMove += Move;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onMove -= Move;
    }

    private void Move(Vector2 movement_direction)
    {
        if (!_areControlsLocked)
        {
            Vector3 movement = new Vector3();
            movement.y = movement_direction.y;

            transform.localPosition += movement * Time.deltaTime;
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
