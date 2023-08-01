using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public GameObject player;
    public TMP_Text score;

    public GameObject ballPrefab;
    Vector3 originBall = new Vector3(0, 5, 0);

    public GameObject gameState;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider ball)
    {
        // Destruir la bola anterior
        Destroy(ball.gameObject);

        // Reproducir sonido
        gameObject.GetComponent<AudioSource>().Play();

        // Aumentar en uno el marcador del jugador
        int newScore = player.GetComponent<Player>().score + 1;
        player.GetComponent<Player>().score = newScore;

        // Actualizar la puntuación en la pantalla
        score.text = newScore.ToString();

        // Determinar el jugador que ha marcado
        int lastPlayer = player.GetComponent<Player>().order;
        gameState.GetComponent<GameState>().lastPlayer = lastPlayer;

        // Controlar el final de la partida
        if (newScore < 2)
        {
            // Generar otra bola
            Instantiate(ballPrefab, originBall, Quaternion.identity);
        }
        else
        {
            // Fin de partida
            gameState.GetComponent<GameState>().endCanvas.SetActive(true);

            GameObject
                .Find("Canvas/End/Winner")
                .GetComponent<TMP_Text>()
                .text = "Player " + lastPlayer.ToString() + " Wins";
        }
    }
}
