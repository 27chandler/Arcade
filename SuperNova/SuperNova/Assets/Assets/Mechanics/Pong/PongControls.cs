using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongControls : PlayerInput, IControllable
{
    [SerializeField] private bool _areControlsLocked;
    [SerializeField] private float _borderTop, _borderBottom;

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

            if ((movement.y > 0.0f) && (transform.localPosition.y >= _borderTop))
            {
                return;
            }
            if ((movement.y < 0.0f) && (transform.localPosition.y <= _borderBottom))
            {
                return;
            }

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
