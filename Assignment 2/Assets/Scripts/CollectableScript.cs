using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    public LevelManagerScript levelManagerScript;
    private Vector3 rotationAngle = new Vector3(0, 0, 10);
    private float rotationSpeed = 8;
    private bool claimed;
    private AudioSource audioSource;
    private Renderer collectableRenderer;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        collectableRenderer = GetComponent<Renderer>();
        claimed = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate
        transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider) {
        // If the player collided with this object, destroy it.
        if (collider.CompareTag("Player")) {
            if (!claimed) {
                claimed = true;
                audioSource.PlayOneShot(audioClip);
                Debug.Log("Gem collision");
                levelManagerScript.AcquiredCollectable();
                collectableRenderer.enabled=false;
                enabled = false;
            }
        }
    }
}
