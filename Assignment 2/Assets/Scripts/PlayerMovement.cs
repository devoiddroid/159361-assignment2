using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float JumpForce;
    public float Speed;

    private Rigidbody rb;
    private CharacterController controller;
    private float Gravity = -9.81f * 2;
    private Vector3 playerVelocity;
    private bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        // Hide the cursor in the preview
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Reset vertical velocity ------------------------------------
        if (controller.isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
            isOnGround = true;
        }

        // Movement handling ------------------------------------------
        Vector3 moveDirection = new Vector3(
            Input.GetAxis("Horizontal"),
            0, 
            Input.GetAxis("Vertical")
        );
        controller.Move(moveDirection * Time.deltaTime * Speed);

        // Jump handling ----------------------------------------------
        if (Input.GetButtonDown("Jump") && isOnGround) {
            playerVelocity.y += Mathf.Sqrt(JumpForce * -3.0f * Gravity);
            isOnGround = false;
            
        }
        playerVelocity.y += Gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
