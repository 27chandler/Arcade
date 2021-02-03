﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUseInteraction : Interaction
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _collider;
    [SerializeField] private Vector3 _holdOffset;

    private Transform _holder;

    private bool _isHeld = false;

    void Start()
    {
        InputManager.Instance._onReturn += DropItem;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onReturn -= DropItem;
    }

    private void FixedUpdate()
    {
        if (_isHeld)
        {
            _rb.position = _holder.position + (_holder.right * _holdOffset.x) + (_holder.up * _holdOffset.y) + (_holder.forward * _holdOffset.z);
            _rb.rotation = _holder.rotation;
        }
    }

    public override void ActivateInteraction(PlayerInteract player_interactor)
    {
        _holder = player_interactor.transform;
        
        _rb.transform.parent = _holder;

        _collider.enabled = false;
        _rb.useGravity = false;

        _isHeld = true;
    }

    private void DropItem()
    {
        _collider.enabled = true;
        _rb.useGravity = true;
        _rb.transform.parent = null;

        _isHeld = false;
    }
}
