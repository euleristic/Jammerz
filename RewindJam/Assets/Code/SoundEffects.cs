using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    public static void PlaySoundEffect(SoundEffect clip)
    {
        if (clip == null) 
        {
            Debug.LogWarning("There's no fockin' sound effect you muppet");
            return; 
        }
        
        var source = new GameObject(clip.name, typeof(AudioSource), typeof(SFXPitchHandler)).GetComponent<AudioSource>();
        source.clip = clip.Clip;
        source.pitch = clip.BasePitch + Random.Range(-clip.PitchVariation, clip.PitchVariation);
        source.volume = clip.BaseVolume + Random.Range(-clip.VolumeVariation, clip.VolumeVariation);
        source.Play();
        Destroy(source.gameObject, clip.Clip.length);
    }
}
[CreateAssetMenu(menuName = "Sound Effect")]
public class SoundEffect : ScriptableObject
{
    public AudioClip Clip;
    [Range(0f, 1f)]
    public float BaseVolume = 0.95f;
    [Range(0f, 1f)]
    public float VolumeVariation = 0.05f;
    [Range(0f, 5f)]
    public float BasePitch = 1f;
    [Range(0f, 5f)]
    public float PitchVariation = 0.3f;
}
