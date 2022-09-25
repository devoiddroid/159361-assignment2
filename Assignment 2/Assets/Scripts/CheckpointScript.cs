using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
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

            // Destroy the object
            Destroy(gameObject);
        }
    }
}
