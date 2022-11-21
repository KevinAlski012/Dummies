using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public Slider volumeSlider;
    public Toggle toggle;

    public void SliderVolume()
    {
        SoundsManager.Instance.audioSource.volume = volumeSlider.value;
    }

    public void SetMute()
    {
        if (toggle.isOn == true)
        {
            SoundsManager.Instance.audioSource.mute = false;
        }
        else
        {
            SoundsManager.Instance.audioSource.mute = true;
        }
    }

    private void Start()
    {
        Screen.SetResolution(540, 960, true);
        
        if (SoundsManager.Instance.audioSource.mute == true)
        {
            toggle.isOn = false;
        }
        else
        {
            toggle.isOn = true;
        }
        
        volumeSlider.value = SoundsManager.Instance.audioSource.volume;
        SoundsManager.Instance.LoadVolume();
    }

    //tombol exit
    public void ExitGame () {
        Application.Quit();
        Debug.Log("Quit Game Success");
    }
    
    //tombol play
    public void PlayGame (string GamePlay) {
        SceneManager.LoadScene(GamePlay);
        Debug.Log("Ini Scene GamePlay Aktif" +GamePlay);
    }

}
