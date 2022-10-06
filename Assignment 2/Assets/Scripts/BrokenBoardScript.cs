using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBoardScript : MonoBehaviour
{
    private bool Falling;
    private float FallTimer = 0.5f;
    private Rigidbody rb;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        Falling = false;
        rb = transform.GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (FallTimer <= 0) {
            rb.constraints = RigidbodyConstraints.None;
        }
        if (transform.position.y <= -80) {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    void FixedUpdate() {
        if (Falling) {
            if (FallTimer > 0.0f) {
                FallTimer -= Time.fixedDeltaTime;
            }
        }
    }

    public void ResetBoardPosition() {
        FallTimer = 0.5f;
        Falling = false;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        transform.position = startPos;
    }

    void OnCollisionEnter(Collision collision) {
        // If the player landed on the board, start counting down to it falling
        if (collision.gameObject.CompareTag("Player")) {
            Falling = true;
        }
    }
}
