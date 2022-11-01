using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    public AudioClip finishlineClip;
    public AudioSource audioSource;
    // private LevelManagerScript levelManager;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // levelManager = GameObject
        //     .FindGameObjectWithTag("LevelManager")
        //     .GetComponent<LevelManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        // If the player crossed the finish line, flag the level as complete
        if (collider.gameObject.CompareTag("Player")) {
            LevelManagerScript.LevelFinished = true;
            audioSource.PlayOneShot(finishlineClip);
        }
    }
}
