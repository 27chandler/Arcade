using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusInteraction : Interaction,  IControllable
{
    [SerializeField] private bool _isActive = false;
    [Space]
    [SerializeField] private Transform _focusTransform;
    [SerializeField] private PlayerRegister _focusRegister;

    private bool _areControlsLocked = false;

    void Start()
    {
        InputManager.Instance._onReturn += CancelFocus;
    }

    private void OnDestroy()
    {
        InputManager.Instance._onReturn -= CancelFocus;
    }

    public override void ActivateInteraction(PlayerInteract player_interactor)
    {
        if (!_areControlsLocked)
        {
            _focusRegister.enabled = true;
            if (!_isActive)
                StartCoroutine(SlidePlayer(player_interactor));

            _isActive = true;
        }
    }

    private IEnumerator SlidePlayer(PlayerInteract player_interactor)
    {
        Transform player_transform = player_interactor._player.transform;
        Vector3 player_start = player_transform.position;
        float lerp_progress = 0.0f;

        while (lerp_progress < 1.0f)
        {
            player_transform.position = Vector3.Lerp(player_start, _focusTransform.position, lerp_progress);

            lerp_progress += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Finished Slide");

        while (_isActive)
        {
            player_transform.position = _focusTransform.position;
            yield return null;
        }

        yield return null;
    }

    private void CancelFocus()
    {
        _focusRegister.enabled = false;
        _isActive = false;
    }

    void IControllable.FreezeControls()
    {
        _areControlsLocked = true;
        CancelFocus();
    }

    void IControllable.UnFreezeControls()
    {
        _areControlsLocked = false;
    }
}
