using UnityEngine;
using UnityEngine.UI;

public class Audio_SetVolume : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        musicSlider.value = Audio_Manager.instance.musicValue;
        sfxSlider.value = Audio_Manager.instance.sfxValue;
    }

    public void SetMusicVolume(float value)
    {
        Audio_Manager.instance.music_AudioMixer.audioMixer.SetFloat("MusicVol", Mathf.Log10(value) * 20);

        Audio_Manager.instance.musicValue = value;
    }
    
    public void SetSFXVolume(float value)
    {
        Audio_Manager.instance.sfx_AudioMixer.audioMixer.SetFloat("SfxVol", Mathf.Log10(value) * 20);

        Audio_Manager.instance.sfxValue = value;
    }
}
