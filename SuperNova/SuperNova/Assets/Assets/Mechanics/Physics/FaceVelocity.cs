using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceVelocity : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + _rb.velocity.normalized);
    }
}
