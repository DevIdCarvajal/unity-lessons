using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisions : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider ball)
    {
        ball.gameObject.GetComponent<BallMovement>().speedY *= -1;
    }
}
