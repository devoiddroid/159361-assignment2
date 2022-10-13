using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    private GameObject checkpointNotice;
    private IEnumerator showTempUI;

    // Start is called before the first frame update
    void Start()
    {
        checkpointNotice = GameObject.FindGameObjectWithTag("CheckpointNotice");
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
            // GameObject checkpointNotice = GameObject.FindGameObjectWithTag("CheckpointNotice");
            // checkpointNotice.SetActive(true);
            showTempUI = WaitAndPrint(2f);
            StartCoroutine(showTempUI);
            // checkpointNotice.SetActive(false);

            // Destroy the object
            Destroy(gameObject);

            
        }
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        checkpointNotice.SetActive(true);
        yield return new WaitForSeconds(2f);
        checkpointNotice.SetActive(false);
    }
}
