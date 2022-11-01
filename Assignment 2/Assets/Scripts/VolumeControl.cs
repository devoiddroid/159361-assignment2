using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    private GameObject slider;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        slider = this.gameObject;
    }

    public void SetVolume(float volume){
        if(slider.CompareTag("musicvolume")){
            audioMixer.SetFloat("MusicVolume", volume);
        }
        else if(slider.CompareTag("sfxvolume")){
            audioMixer.SetFloat("EffectsVolume", volume);
        } else {
            audioMixer.SetFloat("MasterVolume", volume);
        }
    }

}
