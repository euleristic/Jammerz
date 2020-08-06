using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    [SerializeField]private float _swayAngle, _swaySpeed;
    private float _startAngle;
    private float _angle;
    private Rigidbody2D _rb;
    [SerializeField] private bool _horizontal = false;
    
    private void Start()
    {
        _startAngle = transform.rotation.eulerAngles.z;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float testNumber = _horizontal ? _rb.velocity.x : _rb.velocity.y;
        if(Mathf.Abs(testNumber * TimeManager.GetTimeFactor()) > 0f)
        {
            _angle -= testNumber * _swaySpeed *  TimeManager.GetTimeFactor();
            _angle = Mathf.Clamp(_angle, -_swayAngle, _swayAngle);
        }
        else
        {
            _angle -= Mathf.Min(Mathf.Sign(_angle) * _swaySpeed, Mathf.Abs(_angle));
        }
        transform.rotation = Quaternion.Euler(0f, 0f, _startAngle + _angle);
    }
}
