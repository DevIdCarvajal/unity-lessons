using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public GameObject rigidBall;
    public GameObject rigidLeftFlipper;
    public GameObject rigidRightFlipper;

    public float ballForce = 200f;
    public float flipperForce = 600f;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBall
                .GetComponent<Rigidbody>()
                .AddForce(new Vector3(Random.Range(-50f, 50f), 0, ballForce));
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rigidLeftFlipper
                .GetComponent<Rigidbody>()
                .AddForce(new Vector3(0, 0, flipperForce));
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            rigidRightFlipper
                .GetComponent<Rigidbody>()
                .AddForce(new Vector3(0, 0, flipperForce));
        }
    }
}
