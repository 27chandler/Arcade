using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Vector3 _movementDirection = new Vector3(1.0f, 1.0f,0.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += _movementDirection * _movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //_movementDirection *= collision.GetContact(0).normal;
        //BounceObject bounce_surface = collision.gameObject.GetComponent<BounceObject>();

        Debug.Log("Input direction: " + _movementDirection);
        Debug.Log("Input normal: " + collision.GetContact(0).normal);
        Debug.Log("Converted normal: " + collision.GetContact(0).thisCollider.transform.InverseTransformDirection(collision.GetContact(0).normal));

        _movementDirection = Vector3.Reflect(_movementDirection, transform.parent.InverseTransformDirection(collision.GetContact(0).normal));
        Debug.Log("Reflected direction: " + _movementDirection);
        //_movementDirection = transform.InverseTransformDirection(_movementDirection);
        //Debug.Log("Converted direction: " + _movementDirection);
        //_movementDirection.z = 0.0f;

        //// Find which side the collision was on
        //    Vector3 collision_direction = transform.localPosition - transform.InverseTransformPoint(collision.GetContact(0).point);
        //collision_direction = collision_direction.normalized;
        //Debug.Log(collision_direction);

        //if (Mathf.Abs(collision_direction.x) > Mathf.Abs(collision_direction.y))
        //{
        //    _movementDirection.y = -_movementDirection.y;
        //}
        //else
        //{
        //    _movementDirection.x = -_movementDirection.x;
        //}
    }
}
