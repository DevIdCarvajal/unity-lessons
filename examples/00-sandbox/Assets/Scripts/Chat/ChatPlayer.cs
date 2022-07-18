using Unity.Netcode;
using UnityEngine;
using System;
using TMPro;

public class ChatPlayer : NetworkBehaviour
{
  public NetworkVariable<int> Conversation = new NetworkVariable<int>();

  public override void OnNetworkSpawn()
  {
    if (IsOwner)
    {
      AddMessage();
    }
  }

  public void AddMessage()
  {
    if (NetworkManager.Singleton.IsServer)
    {
      Conversation.Value = GetMessageFromInput();
    }
    else
    {
      SubmitPositionRequestServerRpc();
    }
  }

  [ServerRpc]
  void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
  {
    Conversation.Value += GetMessageFromInput();
  }

  int GetMessageFromInput()
  {
    return 1;
  }

  void Update()
    {
      GameObject
        .Find("Canvas/ClientPanel/Text")
        .GetComponent<TMP_Text>()
        .text = Conversation.Value.ToString();
    }
}