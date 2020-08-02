using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterSlider, musicSlider, sfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

    public void SetMasterVol()
    {
       mixer.SetFloat("MasterVolume", masterSlider.value);
    }

    public void SetMusicVol()
    {
        mixer.SetFloat("MusicVolume", masterSlider.value);
    }

    public void SetSFXvol()
    {
        mixer.SetFloat("SFXvolume", masterSlider.value);
    }
}
