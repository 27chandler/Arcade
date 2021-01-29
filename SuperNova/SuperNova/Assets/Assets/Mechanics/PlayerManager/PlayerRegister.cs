using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRegister : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    // Start is called before the first frame update
    void OnEnable()
    {
        PlayerManager.Instance.RegisterPlayer(this.gameObject);
    }

    // Update is called once per frame
    void OnDisable()
    {
        PlayerManager.Instance.UnRegisterPlayer(this.gameObject);
    }

    public void FreezeControls()
    {
        _input.enabled = false;
    }

    public void UnFreezeControls()
    {
        _input.enabled = true;
    }
}
