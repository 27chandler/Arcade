using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _followDistance;
    [SerializeField] private float _followHeight;
    [SerializeField] private Transform _followTarget;
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(null);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 target_forward_flattened = _followTarget.forward;
        target_forward_flattened.y = 0.0f;
        target_forward_flattened.Normalize();

        transform.position = Vector3.Lerp(transform.position, _followTarget.position - (target_forward_flattened * _followDistance) + (Vector3.up * _followHeight), 0.3f);
        transform.LookAt(_followTarget,Vector3.up);

        //transform.position = _followTarget.position + _followPos;
    }
}
