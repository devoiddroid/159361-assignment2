using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 cameraPos = new Vector3(
            playerPos.x, 
            4, 
            playerPos.z - 6
        );
        transform.position = cameraPos;
    }
}
