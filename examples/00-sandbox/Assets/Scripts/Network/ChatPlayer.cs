using Unity.Netcode;
using UnityEngine;
using System;
using TMPro;

public class ChatPlayer : NetworkBehaviour
{
  public NetworkVariable<int> TotalMessages = new NetworkVariable<int>();

  int total = 0;

  public override void OnNetworkSpawn()
  {
    UpdateChat();
  }

  public void UpdateChat()
  {
    if (NetworkManager.Singleton.IsServer)
    {
      total = TotalMessages.Value + 5;
      TotalMessages.Value = TotalMessages.Value + 5;
    }
    else
    {
      SubmitTotalMessagesRequestServerRpc();
    }
  }

  [ServerRpc]
  void SubmitTotalMessagesRequestServerRpc(ServerRpcParams rpcParams = default)
  {
    TotalMessages.Value = TotalMessages.Value + 5;
  }

  void Update()
  {
    total = TotalMessages.Value;
    
    GameObject
      .Find("Canvas/ClientPanel/Text")
      .GetComponent<TMP_Text>()
      .text = total.ToString();
  }
}