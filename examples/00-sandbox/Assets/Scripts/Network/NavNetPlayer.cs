using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

public class NavNetPlayer : NetworkBehaviour
{
    NavMeshAgent navMeshAgent;
    Vector3 hitPoint;
    
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

    public override void OnNetworkSpawn()
    {
        hitPoint = transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 point)
    {
        hitPoint = point;

        if (NetworkManager.Singleton.IsServer)
        {
            Position.Value = hitPoint;
        }
        else
        {
            SubmitPositionRequestServerRpc();
        }
    }

    [ServerRpc]
    void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
    {
        Position.Value = hitPoint;
    }

    void Update()
    {
        navMeshAgent.SetDestination(hitPoint);
    }
}