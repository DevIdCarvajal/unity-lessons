using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavAgent : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    int destination = 0;
    const float speedWander = 2;
    const float speedChase = 3;

    [SerializeField]
    Transform[] points;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;

        GotoNextPoint();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5) &&
            hit.collider.CompareTag("Player")) // Chasing player
        {
            // Move to character
            navMeshAgent.SetDestination(hit.point);

            navMeshAgent.speed = speedChase;
        }
        else // Wandering
        {
            if (!navMeshAgent.pathPending &&
                navMeshAgent.remainingDistance < 0.5f)
            {
                GotoNextPoint();

                navMeshAgent.speed = speedWander;
            }
        }
    }
    
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        
        navMeshAgent.SetDestination(points[destination].position);

        destination = (destination + 1) % points.Length;
    }
}
