using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource _musicSource;
    private void Start()
    {
        _musicSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        _musicSource.pitch = TimeManager.GetTimeFactor();
    }
}
