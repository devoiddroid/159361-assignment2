using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private float playerYpos;
    private Vector3 offset;
    // private Quaternion cameraRotation;
    private PlayerMovement playerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        playerYpos = player.transform.position.y;
        // cameraRotation = transform.rotation;
        playerMovementScript = player.GetComponent<PlayerMovement>();
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate() {
        Vector3 playerPos = player.transform.position;
        Vector3 targetPos = new Vector3(
            playerPos.x, 
            playerYpos + 2, 
            playerPos.z
        );
        targetPos = targetPos + offset;
        targetPos.x = playerPos.x;
        Vector3 smoothFollow = Vector3.Lerp(transform.position, targetPos, 0.1f);

        transform.position = smoothFollow;

        // Don't look at the player unless they're on the ground, otherwise we lose sight of the level terrain
        if (playerMovementScript.isOnGround) {
            transform.LookAt(player.transform.Find("FocalPoint").transform);
        }
        
    }
}
