using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance { get; set; }
    public AudioSource audioSource;
    public Slider sliderVolume;
    public Toggle muteToggle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveVolume()
    {
        Instance.audioSource.volume = sliderVolume.value;
        PlayerPrefs.SetFloat("VolumeValue", sliderVolume.value);
        LoadVolume();
    }

    public void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        sliderVolume.value = volumeValue;
    }

    public void MuteSound()
    {
        if (muteToggle.isOn == true)
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
        }
    }
}
