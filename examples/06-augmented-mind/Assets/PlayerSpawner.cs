using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    void Start()
    {
        Invoke("SpawnPlayer", 3);
    }

    void SpawnPlayer() {
        Instantiate(Player);
    }
}
