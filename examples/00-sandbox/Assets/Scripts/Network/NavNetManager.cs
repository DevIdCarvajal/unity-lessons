using Unity.Netcode;
using UnityEngine;

public class NavNetManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    // User Interface to create Host/Server/Client connections & get status info
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));

        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            StartButtons();
        }
        else
        {
            StatusLabels();
        }

        GUILayout.EndArea();
    }

    // Buttons
    static void StartButtons()
    {
        if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
        if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
        if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
    }

    // Info
    void StatusLabels()
    {
        string mode = NetworkManager.Singleton.IsHost ?
            "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

        GUILayout.Label("Transport: " +
            NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
        GUILayout.Label("Mode: " + mode);

        if (NetworkManager.Singleton.IsServer)
        {
            // Spawn new enemy
            if (GUILayout.Button("Enemy", GUILayout.Width(100)))
            {
                GameObject enemy = Instantiate(enemyPrefab, new Vector3(8.3f, 0.8f, 0), Quaternion.identity);
                enemy.GetComponent<NetworkObject>().Spawn();
            }

            // PowerUp a client
            foreach (ulong uid in NetworkManager.Singleton.ConnectedClientsIds)
            {
                if (GUILayout.Button("Client " + uid, GUILayout.Width(100)))
                {
                    NetworkManager
                        .Singleton
                        .SpawnManager
                        .GetPlayerNetworkObject(uid)
                        .GetComponent<NavNetPlayer>()
                        .PowerUpClientRpc();
                }
            }
        }
    }

    // Local GameObject logic
    // (as event handling, firing networked action to Network Object)
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                // Selecting local network object
                NetworkObject playerObject = NetworkManager.Singleton.SpawnManager.GetLocalPlayerObject();
                NavNetPlayer player = playerObject.GetComponent<NavNetPlayer>();
                player.Move(hit.point);
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (NetworkManager.Singleton.IsServer)
            {
                foreach (ulong uid in NetworkManager.Singleton.ConnectedClientsIds)
                {
                    NetworkManager
                        .Singleton
                        .SpawnManager
                        .GetPlayerNetworkObject(uid)
                        .GetComponent<NavNetPlayer>()
                        .PowerUpClientRpc();
                }
            }
        }
    }
}