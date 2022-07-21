using Unity.Netcode;
using UnityEngine;
using TMPro;

public class ChatManager : MonoBehaviour
{
  [SerializeField]
  GameObject StartPanel;

  [SerializeField]
  GameObject ServerPanel;

  [SerializeField]
  GameObject ClientPanel;

  void Start()
  {
    StartPanel.SetActive(true);
    ServerPanel.SetActive(false);
    ClientPanel.SetActive(false);
  }

  public void CreateRoom()
  {
    if (NetworkManager.Singleton.StartHost())
    {
      StartPanel.SetActive(false);
      ServerPanel.SetActive(true);
      ClientPanel.SetActive(false);
    }
  }

  public void JoinRoom()
  {
    if (NetworkManager.Singleton.StartClient())
    {
      StartPanel.SetActive(false);
      ServerPanel.SetActive(false);
      ClientPanel.SetActive(true);
    }
  }

  public void CloseRoom()
  {
    NetworkManager.Singleton.Shutdown();

    StartPanel.SetActive(true);
    ServerPanel.SetActive(false);
    ClientPanel.SetActive(false);
  }

  void Update()
  {
    if (NetworkManager.Singleton.IsServer)
    {
      int totalClients = NetworkManager.Singleton.ConnectedClientsIds.Count;

      GameObject
        .Find("Canvas/ServerPanel/Text")
        .GetComponent<TMP_Text>()
        .text = "Connected clients: " + totalClients;
    }
    else // IsClient
    {
      if (Input.GetKeyDown(KeyCode.Return))
      {
        NetworkManager
          .Singleton
          .SpawnManager
          .GetLocalPlayerObject()
          .GetComponent<ChatPlayer>()
          .UpdateChat();
      }
    }
  }
}
