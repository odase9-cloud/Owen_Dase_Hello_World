using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    void Start()
    {
        musicVolumeSlider.value =
            PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolumeSlider.value =
            PlayerPrefs.GetFloat("SFXVolume", 1f);
        OnMainVolumeChange();
    }

    public void OnMainVolumeChange()
    {
        SetVolume("MusicAudio", musicVolumeSlider.value);
        SetVolume("SFXAudio", sfxVolumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
        PlayerPrefs.Save();
    }

    void SetVolume(string parameterName, float sliderValue)
    {
        float volume;

        if (sliderValue <= 0.0001f)
        {
            volume = -80f;
        }
        else
        {
            volume = Mathf.Log10(sliderValue) * 20f;
        }

        mainAudioMixer.SetFloat(parameterName, volume);
    }
}