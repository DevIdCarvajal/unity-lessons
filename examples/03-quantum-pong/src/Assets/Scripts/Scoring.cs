using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public GameObject player;
    public TMP_Text score;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider ball)
    {
        int newScore = player.GetComponent<PlayerMovement>().score + 1;
        player.GetComponent<PlayerMovement>().score = newScore;

        score.text = "27";
    }
}
