using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public float speed = 10;
    public int score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        // Controles de teclado (dentro de los límites)
        
        // Arriba
        if( Input.GetKey( up ) && transform.position.y < 8.5 )
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        // Abajo
        if( Input.GetKey( down ) && transform.position.y > 1.5 )
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter(Collider ball)
    {
        // Cambiar dirección de la bola y aumentar su velocidad
        ball.gameObject.GetComponent<Ball>().speedX *= -1.2f;

        // Reproducir sonido
        gameObject.GetComponent<AudioSource>().Play();
    }
}
