using Unity.Netcode;
using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{
  bool connected = false;

  [SerializeField]
  GameObject StartPanel;

  [SerializeField]
  GameObject ServerPanel;

  [SerializeField]
  GameObject ClientPanel;

  void Awake()
  {
    Screen.fullScreen = false;
  }

  void Start()
  {
    StartPanel.SetActive(true);
    ServerPanel.SetActive(false);
    ClientPanel.SetActive(false);
  }

  public void CreateRoom()
  {
    if (NetworkManager.Singleton.StartServer())
    {
      StartPanel.SetActive(false);
      ServerPanel.SetActive(true);
      ClientPanel.SetActive(false);

      connected = true;
    }
  }

  public void JoinRoom()
  {
    if (NetworkManager.Singleton.StartClient())
    {
      StartPanel.SetActive(false);
      ServerPanel.SetActive(false);
      ClientPanel.SetActive(true);

      connected = true;
    }
  }

  public void CloseRoom()
  {
    NetworkManager.Singleton.Shutdown();

    StartPanel.SetActive(true);
    ServerPanel.SetActive(false);
    ClientPanel.SetActive(false);

    connected = false;
  }

  void Update()
  {
    if (connected)
    {
      if (NetworkManager.Singleton.IsServer)
      {
        int totalClients = NetworkManager.Singleton.ConnectedClientsIds.Count;

        GameObject
          .Find("Canvas/ServerPanel/Text")
          .GetComponent<TMP_Text>()
          .text = "Connected clients: " + totalClients;

        // Broadcasting
        foreach (ulong uid in NetworkManager.Singleton.ConnectedClientsIds)
        {
          NetworkManager
            .Singleton
            .SpawnManager
            .GetPlayerNetworkObject(uid)
            .GetComponent<ChatPlayer>()
            .AddMessage();
        }
      }

      if (NetworkManager.Singleton.IsClient)
      {
        var player = NetworkManager
                      .Singleton
                      .SpawnManager
                      .GetLocalPlayerObject()
                      .GetComponent<ChatPlayer>();
                          
        player.AddMessage();
      }
    }
  }
}
