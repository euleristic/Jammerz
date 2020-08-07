using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTraveller : MonoBehaviour
{
    [SerializeField] private float _slowSpeed = -.35f, _maxSlowDownTime = 3f, _currentSlowDownTime, _chargeTime = .25f, _chargeWait = 1f;
    private float _nextCharge = -100f;
    private bool _reversing;

    private bool _wasfullLastFrame = true;
    [SerializeField] private SoundEffect _fullyChargedSFX;

    private void Start()
    {
        _currentSlowDownTime = _maxSlowDownTime;
    }

    public void ResetChargeTime()
    {
        _nextCharge = TimeManager.GetRelativeTime() + _chargeWait;
    }
    private void FixedUpdate()
    {
        if (_reversing)
        {
            _nextCharge = TimeManager.GetRelativeTime() + _chargeWait;
            _currentSlowDownTime += Mathf.Min(0f, TimeManager.GetTimeFactor()) * Time.fixedDeltaTime;

        }
        if(TimeManager.GetRelativeTime() > _nextCharge)
        {
            _currentSlowDownTime += TimeManager.GetTimeFactor() * _chargeTime * Time.fixedDeltaTime;
        }
        _currentSlowDownTime = Mathf.Clamp(_currentSlowDownTime, 0f, _maxSlowDownTime);
        if (_currentSlowDownTime == _maxSlowDownTime && !_wasfullLastFrame) SoundEffects.PlaySoundEffect(_fullyChargedSFX);


        _wasfullLastFrame = (_currentSlowDownTime == _maxSlowDownTime);
       
    }

    public bool CanReverseTime()
    {
        return _currentSlowDownTime > 0f;
    }

    public void ReverseTime()
    {
        if(!_reversing)
        {
            TimeManager.SetTimeFactor(_slowSpeed);
        }
        _reversing = true;
    }

    public void ResumeTime()
    {
        if(_reversing)
        {
            TimeManager.SetTimeFactor(1f);
        }
        _reversing = false;
    }

    public float GetSlowDownMeterPercent()
    {
        return _currentSlowDownTime / _maxSlowDownTime;
    }

}
