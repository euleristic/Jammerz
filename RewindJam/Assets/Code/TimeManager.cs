﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static float _relativeTime;
    private static float _timeFactor = 1f;

    public static bool Debugging = false;
    
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

    public static void SetTimeFactor(float factor)
    {
        LeanTween.value(_timeFactor, factor, 0.5f).setOnUpdate(SetTimeThing);
    }
    public static void SetTimeThing(float t)
    {
        _timeFactor = t;
    }

    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Numlock)) Debugging = !Debugging;

        if (!Debugging) return;
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetTimeFactor(-1f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _timeFactor = -.2f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _timeFactor = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _timeFactor = .2f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _timeFactor = 1f;
        }
    }
}
