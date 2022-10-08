using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 offset;
    private Vector3 targetPos;
    private PlayerMovement playerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        // playerYpos = player.transform.position.y;
        playerMovementScript = player.GetComponent<PlayerMovement>();
        targetPos = new Vector3(
            player.transform.position.x, 
            player.transform.position.y + 2, 
            player.transform.position.z - 6
        );
        transform.position = targetPos;
        offset = transform.position - targetPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate() {
        Vector3 playerPos = player.transform.position;
        targetPos = new Vector3(
            playerPos.x, 
            playerPos.y + 2, 
            playerPos.z - 6
        );
        targetPos = targetPos + offset;
        Vector3 smoothFollow = Vector3.Lerp(transform.position, targetPos, 0.1f);

        transform.position = smoothFollow;

        // Don't look at the player unless they're on the ground, otherwise we lose sight of the level terrain
        if (playerMovementScript.isOnGround) {
            transform.LookAt(player.transform.Find("FocalPoint").transform);
        }
        
    }
}
