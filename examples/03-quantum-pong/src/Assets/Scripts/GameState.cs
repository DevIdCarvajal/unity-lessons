using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public int lastPlayer = 0;
    public GameObject endCanvas;

    void Start()
    {
        endCanvas.SetActive(false);
    }

    void Update()
    {
        
    }

    public void playAgain()
    {
        lastPlayer = 0;

        // Reset game to start...
    }
}
