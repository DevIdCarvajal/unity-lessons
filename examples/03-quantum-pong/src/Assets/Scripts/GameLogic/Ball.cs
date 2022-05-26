using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speedX;
    public float speedY;

    void Start()
    {
        speedX = Random.Range(2, 5);
        speedY = Random.Range(2, 5);
        
        GameObject gameState = GameObject.Find("GameState");

        // Si es el comienzo de la partida (nadie marcó antes)
        if (gameState.GetComponent<GameState>().lastPlayer == 0)
        {
            // Determinar aleatoriamente la dirección inicial de la bola
            int initialX = Random.Range(0, 2);
            int initialY = Random.Range(0, 2);

            if (initialX == 0)
            {
                speedX *= -1;
            }
            if (initialY == 0)
            {
                speedY *= -1;
            }
        }
        else // Si acaba de marcar el jugador izquierdo
        if (gameState.GetComponent<GameState>().lastPlayer == 1)
        {
            // Bola a la izquierda
            speedX *= -1;
        }
        // Si marcó el derecha, la bola ya va a la derecha (speedX > 0)
    }

    void Update()
    {
        // Mover la bola
        transform.Translate(new Vector3(speedX, speedY, 0) * Time.deltaTime);
    }
}
