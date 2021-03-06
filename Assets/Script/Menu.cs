using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioMixer audioMixer;
    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void AudioVolume(float value){
        audioMixer.SetFloat("Menuvolume", value);
    }

}
