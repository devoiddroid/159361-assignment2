using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private LevelManagerScript levelManagerScript;
    [SerializeField]
    private float JumpForce;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float TurnSpeed;

    private CharacterController controller;
    private float Gravity = -9.81f * 2;
    private Vector3 playerVelocity;
    public Vector3 playerResetPosition;
    public bool isOnGround;
    private Animator animator;
    private bool killed;

    // Start is called before the first frame update
    void Start()
    {
        // Hide the cursor in the preview
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        isOnGround = true;
        killed = false;
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
            ResetPlayerPosition();
            levelManagerScript.ResetBrokenBoards();
        }
        // Had to disable character controller for this to work.
        if (killed) {
            controller.enabled = false;
            killed = false;
            ResetPlayerPosition();
            controller.enabled = true;
        }
    }

    private void ResetPlayerPosition() 
    {
        transform.position = playerResetPosition;
    }

    private void Jump() 
    {
        if (Input.GetButtonDown("Jump") && isOnGround) {
            playerVelocity.y += Mathf.Sqrt(JumpForce * -3.0f * Gravity);
            isOnGround = false;
            animator.SetTrigger("Jump");
        }
        playerVelocity.y += Gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Bounce() 
    {
        playerVelocity.y += Mathf.Sqrt(JumpForce * -3.0f * Gravity);
        isOnGround = false;
        animator.SetTrigger("Jump");
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            StartCoroutine(KillPlayer());
        }
    }

    private IEnumerator KillPlayer()
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1.0f;
        killed = true;
        //ResetPlayerPosition();
    }
}
