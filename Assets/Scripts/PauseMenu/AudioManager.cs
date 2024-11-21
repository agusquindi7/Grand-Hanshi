using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sliderMusic, sliderMaster, sliderSFX;

    public void SetMusicVolume()
    {
        float volume = sliderMusic.value;
        mixer.SetFloat("ExposedMusic",Mathf.Log10(volume)*20);
    }

    public void SetSFXVolume()
    {
        float volume = sliderSFX.value;
        mixer.SetFloat("ExposedSFX", Mathf.Log10(volume) * 20);
    }

    public void SetMasterVolume()
    {
        float volume = sliderMaster.value;
        mixer.SetFloat("ExposedMaster", Mathf.Log10(volume) * 20);
    }
}
