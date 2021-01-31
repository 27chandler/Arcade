using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAIPaddle : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _borderTop, _borderBottom;
    [SerializeField] private float _moveBuffer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();
        if (_ball.localPosition.y > transform.localPosition.y + _moveBuffer)
        {
            movement.y = 1.0f;
        }
        if (_ball.localPosition.y < transform.localPosition.y - _moveBuffer)
        {
            movement.y = -1.0f;
        }

        if ((_ball.localPosition.y > transform.localPosition.y + _moveBuffer) && (transform.localPosition.y >= _borderTop))
        {
            return;
        }
        if ((_ball.localPosition.y < transform.localPosition.y - _moveBuffer) && (transform.localPosition.y <= _borderBottom))
        {
            return;
        }

        transform.localPosition += movement * _moveSpeed * Time.deltaTime;
    }
}
