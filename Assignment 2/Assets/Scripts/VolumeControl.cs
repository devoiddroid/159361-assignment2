using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("Volume", 0);
    }

    public void SetVolume(float volume){
        audioMixer.SetFloat("Volume", volume);
    }

}
