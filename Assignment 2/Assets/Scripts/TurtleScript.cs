using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurtleScript : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    private bool attacking;
    private PlayerMovement playerMovement;
    public AudioClip attackClip;
    public AudioClip launchClip;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        animator.SetBool("RunFWD", true);
        animator.SetBool("Attack01", false);
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if attack animation finished then start moving again
        if(attacking && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >1){
            animator.SetBool("RunFWD", true);
            animator.SetBool("Attack01", false);
            attacking = false;
            agent.isStopped = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        // if collides with player transition to attack animation and stop moving
        if(other.gameObject.CompareTag("Player")){
            animator.SetBool("RunFWD", false);
            animator.SetBool("Attack01", true);
            animator.Play("Attack01");
            playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            attacking = true;
            agent.isStopped = true;
        }
    }

    private void AttackSound(){
        audioSource.PlayOneShot(attackClip);
    }

    private void AttackLaunch(){
        audioSource.PlayOneShot(launchClip);
        playerMovement.Bounce();
    }
}
