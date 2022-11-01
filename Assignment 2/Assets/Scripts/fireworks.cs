using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireworks : MonoBehaviour
{
    private ParticleSystem ps;
    private ParticleSystem.Particle[] particles;
    private bool firstSoundPlayed;
    public AudioSource audioSource;
    public AudioClip audioClipOne;
    public AudioClip audioClipTwo;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        firstSoundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if at start play first sound
        if (ps.time <=0.1f && !firstSoundPlayed) {
            firstSoundPlayed = true;
            StartCoroutine(audioTimer());
        }
        /* else if (ps.time > 0.3f){
            firstSoundPlayed = false;
        }
        // if at start of subemitter play second sound
        if (ps.subEmitters.GetSubEmitterSystem(0).time <=0.3f && !secondSoundPlayed){
            secondSoundPlayed = true;
            audioSource.PlayOneShot(audioClipTwo);
        } else if (ps.subEmitters.GetSubEmitterSystem(0).time > 0.3f) {
            secondSoundPlayed = false;
        }
        
            Debug.Log(ps.subEmitters.GetSubEmitterSystem(0).subEmitters.GetSubEmitterSystem(0).time);
        // if at start of sub subemitter play second sound again
        if (ps.subEmitters.GetSubEmitterSystem(0).subEmitters.GetSubEmitterSystem(0).time <= 0.3f && !thirdSoundPlayed){
            thirdSoundPlayed = true;
            audioSource.PlayOneShot(audioClipTwo);
        } else if (ps.subEmitters.GetSubEmitterSystem(0).subEmitters.GetSubEmitterSystem(0).time > 0.3f){
            thirdSoundPlayed = false;
        }*/
    }

    // had to hard code timings for audio.  Could not get it to work from subemitter timings.
    IEnumerator audioTimer() {
        audioSource.PlayOneShot(audioClipOne);
        yield return new WaitForSeconds(3f);
        audioSource.PlayOneShot(audioClipTwo);
        yield return new WaitForSeconds(2.5f);
        audioSource.PlayOneShot(audioClipTwo);
        firstSoundPlayed = false;
    }

}
