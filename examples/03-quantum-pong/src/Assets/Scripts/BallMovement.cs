using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speedX = 3;
    public float speedY = 3;

    void Start()
    {
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
        transform.Translate(new Vector3(speedX, speedY, 0) * Time.deltaTime);
    }
}
