using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _followPos;
    [SerializeField] private Transform _followTarget;
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _followTarget.position + _followPos;
    }
}
