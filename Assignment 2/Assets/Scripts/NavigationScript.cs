using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{

    public Transform navigateTo;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private float moveSpeed;

    private void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        moveSpeed = navMeshAgent.speed;
        animator.SetFloat("MoveSpeed", moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = navigateTo.position;
        if (Vector3.Distance(transform.position, navigateTo.position) <= 0.1){
            animator.SetFloat("MoveSpeed", 0);
        }
    }
    
}
