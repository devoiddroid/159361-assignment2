using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private LevelManagerScript levelManagerScript;

    private AudioSource audioSource;
    private Renderer checkpointRenderer;
    private BoxCollider checkpointCollider;
    private Rigidbody rb;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        checkpointCollider = GetComponent<BoxCollider>();
        checkpointRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            // Bounce the player
            playerMovement.Bounce();

            // Make this the new respawn point
            Vector3 newResetPos = transform.position;
            newResetPos.y += 2;
            playerMovement.playerResetPosition = newResetPos;

            // Show checkpoint notice
            levelManagerScript.StartCoroutine(levelManagerScript.ShowCheckpointNotice());
            // Play checkpoint audio
            audioSource.PlayOneShot(audioClip);

            // hide checkpoint, turn off collisions, and disable script (can't destroy or audio won't play)
            checkpointCollider.enabled=false;
            checkpointRenderer.enabled=false;
            enabled=false;

            // Destroy the checkpoint
            // Destroy(gameObject);
        }
    }
}
