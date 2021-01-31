using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _bounceIncrement;

    private Vector3 _movementDirection = new Vector3(1.0f, 1.0f,0.0f);
    private int _bounceCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += _movementDirection * (_movementSpeed + (_bounceCount * _bounceIncrement)) * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _movementDirection = Vector3.Reflect(_movementDirection, transform.parent.InverseTransformDirection(collision.GetContact(0).normal));
        _bounceCount++;
    }
}
