using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public GameObject rigidBall;
    public GameObject rigidLeftFlipper;
    public GameObject rigidRightFlipper;

    public float ballForce = 20f;
    public float flipperForce = 16f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBall
                .GetComponent<Rigidbody>()
                .AddForce(0, ballForce, 0, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rigidLeftFlipper
                .GetComponent<Rigidbody>()
                .AddForce(0, flipperForce, 0, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            rigidRightFlipper
                .GetComponent<Rigidbody>()
                .AddForce(0, flipperForce, 0, ForceMode.Impulse);
        }
    }
}
