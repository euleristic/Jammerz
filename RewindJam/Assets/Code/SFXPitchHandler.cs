using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPitchHandler : MonoBehaviour
{
    private float _basePitch;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _basePitch = _audioSource.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        _audioSource.pitch = _basePitch * TimeManager.GetTimeFactor();
    }
}
