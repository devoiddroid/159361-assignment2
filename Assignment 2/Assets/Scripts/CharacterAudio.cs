using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{

    public AudioClip runStepClip;
    public AudioClip landClip;
    public AudioClip jumpClip;
    public AudioClip walkStepClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Roar on attack
    private void WalkStep(){
        audioSource.PlayOneShot(walkStepClip);
    }

    private void RunStep(){
        audioSource.PlayOneShot(runStepClip);
    }

    private void JumpUp(){
        audioSource.PlayOneShot(jumpClip);
    }

    private void JumpLand(){
        audioSource.PlayOneShot(landClip);
    }

}
