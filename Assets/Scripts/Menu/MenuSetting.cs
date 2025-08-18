using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuSetting : MonoBehaviour
{
    public Slider MasterVol, MusicVol, SFXVol;
    public AudioMixer mainAudioMixer;

    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("master", Mathf.Log10(MasterVol.value)*20);
    }
    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("music", Mathf.Log10(MusicVol.value) * 20);
    }
    public void ChangeSFXVolume()
    {
        mainAudioMixer.SetFloat("sfx", Mathf.Log10(SFXVol.value) * 20);
    }
}
