using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Charger type enemy.  Some animation bits could be removed so this can be applied multiple assets
// enemy charges back and forward in a line, stunning when it hits stuff and attempting to stop before edges.
// Could add a reversing function if it gets stuck in a corner and can't turn around.
public class ChargerScript : MonoBehaviour
{
    private Vector3 currentPosition;
    private Rigidbody rb;
    private Vector3 currentRotation;
    private Vector3 targetRotation;
    private Vector3 startingRotation;
    private Vector3 eulerRotation;
    private float currentSpeed;
    public float StunTime;
    private bool turning;
    private bool stopping;
    private bool running;
    private bool stunnedStatus;
    private bool edgeTrigger;
    private float stunStartTime;
    private Ray ray;
    // starting orientation = true, reverse = false.
    private bool direction = true;
    private Animator animator;
    public float TurnSpeed = 45f;
    public float MaxSpeed = 10.0f;
    public float Accel = 1500.0f;

    public float EdgeRange = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        currentRotation = transform.eulerAngles;
        print(currentRotation);
        startingRotation = currentRotation;
        currentSpeed = 0;
        turning = false;
        running = true;
        rb = GetComponent<Rigidbody>();
        eulerRotation = new Vector3(0, TurnSpeed, 0);
        animator = GetComponent<Animator>();
        animator.Play("Base Layer.Combat Idle", 0, 0.25f);
        ray = new Ray(transform.position + (transform.forward * 3f) + (transform.up * 1.5f), Vector3.down);
        
    }

    // Update is called once per frame
    // Should add all animations to here.
    void Update()
    {
        Debug.DrawRay(ray.origin, ray.direction * 3);
    }

    void FixedUpdate() {
        // main physics
        if(stunnedStatus) {
            Stunned(stunStartTime);
        } 
        else {

            if(!stopping) {
                if (running) {
                    if (currentSpeed < MaxSpeed){
                        float accelTick = Accel * Time.fixedDeltaTime;
                        rb.AddForce(transform.forward * accelTick, ForceMode.Acceleration);
                    } 
                    currentSpeed = rb.velocity.magnitude;
                    EdgeCheck();
                } else if (turning) {
                        
                    Quaternion incrementRotation = Quaternion.Euler(eulerRotation * Time.deltaTime);
                    rb.MoveRotation(rb.rotation * incrementRotation);
                        currentRotation = transform.eulerAngles;
                        
                        if (Vector3.Distance(currentRotation,targetRotation) < 5){
                            transform.eulerAngles = targetRotation;
                            turning = false;
                            running = true;
                            animator.SetBool("Run Forward", true);
                            animator.SetBool("WalkForward", false);                           
                        }
                    }                  
            } else {
                deccelerate();
                if (currentSpeed <=1) {
                    currentSpeed = 0;
                    rb.velocity = new Vector3(0,0,0);
                    stopping = false;
                    ChangeDirection();
                }
            }
        }
    }

    // slow down to a stop
    private void deccelerate() {
        print("stopping");
        rb.velocity = new Vector3(rb.velocity.x *0.8f, rb.velocity.y*0.8f, rb.velocity.z*0.8f);
        currentSpeed = rb.velocity.magnitude;

    }

    // Function takes raycast from in front of agent and checks if there is a floor ahead.
    private void EdgeCheck(){
        ray.origin = transform.position + (transform.forward * 3f) + (transform.up * 1.5f);
        bool rayResults = Physics.Raycast(ray, 3.0f);
        if (!rayResults) {
            print("edge");
            stopping = true;
        }
    }

    private void OnCollisionEnter(Collision other) {
        // stuns creature on collision
        print("collision");
        if (other.gameObject.tag != "ground" && other.gameObject.tag != "Player") {
            stunnedStatus = true;
            stunStartTime = Time.time;
        }
        if (other.gameObject.tag == "Player") {
            stopping = true;
            animator.Play("Attack5");
            
            print("attack");
        }

    }

    private void ChangeDirection() {
        // turns around 180 degrees
        print("turning");
        running = false;
        turning = true;
        animator.SetBool("Run Forward", false);
        animator.SetBool("WalkForward", true);
        currentSpeed = 0;
        if (direction) {
            targetRotation = currentRotation + new Vector3 (0,180,0);
            direction = false;
        } else {
            targetRotation = startingRotation;
            direction = true;
        }
    }

    // function for stun timer
    private void Stunned(float startTime){
        print("stunned");
        if (Time.time-startTime < StunTime){
            animator.SetBool("Run Forward", false);
            animator.SetBool("Stunned Loop", true);
        } else {
            stunnedStatus = false;
            animator.SetBool("Stunned Loop", false);
            ChangeDirection();
        }
    }
}
