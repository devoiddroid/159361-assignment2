using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] points;
    private int nextPoint = 0;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;
    }

    // Set destination to the next point then iterate through array.
    private void goToNextPoint(){
        navMeshAgent.SetDestination(points[nextPoint].position);
        if(nextPoint +1 != points.Length){
            nextPoint +=1;
        }
        else {
            nextPoint = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if close enough to destination and calculate next destination
        if(!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= 0.05f) {
            goToNextPoint();
            Debug.Log(nextPoint);
        }
    }
}
