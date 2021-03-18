using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventButtonInteract : Interaction
{
    [SerializeField] private UnityEvent _activationEvents;

    public override void ActivateInteraction(PlayerInteract player_interactor)
    {
        _activationEvents.Invoke();
    }
}
