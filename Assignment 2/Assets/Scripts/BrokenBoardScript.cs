using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBoardScript : MonoBehaviour
{
    private bool Falling;
    private float FallTimer = 1.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Falling = false;
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FallTimer <= 0) {
            rb.constraints = RigidbodyConstraints.None;
        }
        if (transform.position.y <= -20) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        if (Falling) {
            if (FallTimer > 0.0f) {
                FallTimer -= Time.fixedDeltaTime;
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        // If the player landed on the board, start counting down to it falling
        if (collision.gameObject.CompareTag("Player")) {
            Falling = true;
        }
    }
}
