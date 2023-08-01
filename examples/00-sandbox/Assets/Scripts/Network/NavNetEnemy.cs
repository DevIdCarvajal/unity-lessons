using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

public class NavNetEnemy : NetworkBehaviour
{
    NavMeshAgent navMeshAgent;
    
    const float speedWander = 2;
    const float speedChase = 3;

    int destination = 0;
    Vector3[] points = {
        new Vector3(8.3f, 0, 3.5f),
        new Vector3(13, 0, 3.5f),
        new Vector3(13, 0, -4),
        new Vector3(8.3f, 0, -4)
    };

    public NetworkVariable<Vector3> NextPoint = new NetworkVariable<Vector3>();

    public override void OnNetworkSpawn()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;

        if (IsOwner)
        {
            GotoNextPoint();
        }
    }

    public void Chase(Vector3 hitPoint)
    {
        if (NetworkManager.Singleton.IsServer)
        {
            NextPoint.Value = hitPoint;
        }
        else
        {
            SubmitNextPointRequestServerRpc(hitPoint);
        }
    }

    public void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        
        if (NetworkManager.Singleton.IsServer)
        {
            NextPoint.Value = points[destination];

            destination = (destination + 1) % points.Length;
        }
        else
        {
            SubmitNextPointRequestServerRpc(points[destination], true);
        }
    }

    [ServerRpc]
    void SubmitNextPointRequestServerRpc(Vector3 point, bool goToNext = false)
    {
        NextPoint.Value = point;

        if (goToNext)
            destination = (destination + 1) % points.Length;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Chasing player
        if (Physics.Raycast(ray, out hit, 5) &&
            hit.collider.CompareTag("Player"))
        {
            // Move to character
            Chase(hit.point);

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
        
        navMeshAgent.SetDestination(NextPoint.Value);
    }
}