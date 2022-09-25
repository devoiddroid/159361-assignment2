using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float JumpForce;
    public float Speed;
    public float TurnSpeed;

    private Rigidbody rb;
    private CharacterController controller;
    private float Gravity = -9.81f * 2;
    private Vector3 playerVelocity;
    public Vector3 playerResetPosition;
    public bool isOnGround;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Hide the cursor in the preview
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        isOnGround = true;
        playerResetPosition = transform.position;
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
        if (moveDirection != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(moveDirection / TurnSpeed);
            animator.SetFloat("MoveSpeed", 1);
        } else {
            animator.SetFloat("MoveSpeed", 0);
        }
        controller.Move(moveDirection * Time.deltaTime * Speed);

        // Jump handling ----------------------------------------------
        Jump();

        // Reset player position --------------------------------------
        if (transform.position.y <= -20) {
            transform.position = playerResetPosition;
        }
    }

    private void Jump() {
        if (Input.GetButtonDown("Jump") && isOnGround) {
            playerVelocity.y += Mathf.Sqrt(JumpForce * -3.0f * Gravity);
            isOnGround = false;
            animator.SetTrigger("Jump");
        }
        playerVelocity.y += Gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Bounce() {
        playerVelocity.y += Mathf.Sqrt(JumpForce * -3.0f * Gravity);
        isOnGround = false;
        animator.SetTrigger("Jump");
        Jump();
    }
}
