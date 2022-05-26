using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speedX = 3;
    public float speedY = 3;

    void Start()
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

    void Update()
    {
        // Mover la bola
        transform.Translate(new Vector3(speedX, speedY, 0) * Time.deltaTime);
    }
}
