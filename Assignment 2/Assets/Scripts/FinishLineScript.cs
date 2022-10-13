using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    private LevelManagerScript levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject
            .FindGameObjectWithTag("LevelManager")
            .GetComponent<LevelManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        // If the player landed on the board, start counting down to it falling
        if (collider.gameObject.CompareTag("Player")) {
            LevelManagerScript.LevelFinished = true;
        }
    }
}
