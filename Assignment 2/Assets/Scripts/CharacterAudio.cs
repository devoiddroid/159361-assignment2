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

    // walking step sound
    private void WalkStep(){
        audioSource.PlayOneShot(walkStepClip);
    }
    // running step sound
    private void RunStep(){
        audioSource.PlayOneShot(runStepClip);
    }
    // sound for jump takeoff
    private void JumpUp(){
        audioSource.PlayOneShot(jumpClip);
    }
    // sound for jump landing
    private void JumpLand(){
        audioSource.PlayOneShot(landClip);
    }

}
