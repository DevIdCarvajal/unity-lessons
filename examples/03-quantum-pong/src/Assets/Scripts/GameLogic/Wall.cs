using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider ball)
    {
        // Cambiar dirección de la bola
        ball.gameObject.GetComponent<Ball>().speedY *= -1;
    }
}
