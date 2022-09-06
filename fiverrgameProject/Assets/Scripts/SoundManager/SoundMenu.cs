using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundMenu : MonoBehaviour
{
    public Slider VolumeSlider;
    public AudioMixer mixer;
    public void SetVolume()
    {
        mixer.SetFloat("volume", VolumeSlider.value);
    }
}
