using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAudio : MonoBehaviour
{
    public AudioClip roarClip;
    public AudioClip stepClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Roar on attack
    private void Roar(){
        audioSource.PlayOneShot(roarClip);
    }

    private void Step(){
        audioSource.PlayOneShot(stepClip);
    }
}
