using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static float _relativeTime;
    private static float _timeFactor;
    
    private void Awake()
    {
        var t = FindObjectOfType<TimeManager>();
        if (t != this) //force singleton
        {
            Destroy(this);
        }
        _relativeTime = Time.time;
    }

    public static float GetTimeFactor()
    {
        return _timeFactor;
    }

    public static float GetRelativeTime()
    {
        return _relativeTime;
    }

    private void FixedUpdate()
    {
        _relativeTime += Time.deltaTime * _timeFactor;        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _timeFactor = -1f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _timeFactor = -.5f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _timeFactor = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _timeFactor = .5f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _timeFactor = 1f;
        }
    }
}
