using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

public class NavNetPlayer : NetworkBehaviour
{
    NavMeshAgent navMeshAgent;

    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

    public override void OnNetworkSpawn()
    {
        // Initialize local network object
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (IsOwner)
        {
            Move(transform.position);
        }
    }

    public void Move(Vector3 hitPoint)
    {
        // Server case
        if (NetworkManager.Singleton.IsServer)
        {
            // Local value is networked (shared) value
            Position.Value = hitPoint;
        }
        else // Client case
        {
            // Local value is sent to server to share
            SubmitPositionRequestServerRpc(hitPoint);
        }
    }

    // Executed in client-side
    [ClientRpc]
    public void PowerUpClientRpc()
    {
        navMeshAgent.speed *= 1.5f;
    }

    // Executed in server-side
    [ServerRpc]
    void SubmitPositionRequestServerRpc(Vector3 hitPoint)
    {
        // Update network (shared) variable from client to server
        Position.Value = hitPoint;
    }

    void Update()
    {
        // Always networked (shared) value
        navMeshAgent.SetDestination(Position.Value);
    }
}