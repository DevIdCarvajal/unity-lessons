using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public GameObject rigidBall;
    public GameObject rigidLeftFlipper;
    public GameObject rigidRightFlipper;

    public float ballForce = 600f;
    public float flipperForce = 400f;
    
    // public float ballImpulse = 20f;
    // public float flipperImpulse = 16f;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBall
                .GetComponent<Rigidbody>()
                //.AddForce(0, ballImpulse, 0, ForceMode.Impulse);
                .AddRelativeForce(new Vector3(Random.Range(-50f, 50f), 0, ballForce));
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rigidLeftFlipper
                .GetComponent<Rigidbody>()
                //.AddForce(0, flipperImpulse, 0, ForceMode.Impulse);
                .AddForce(new Vector3(0, 0, flipperForce));
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            rigidRightFlipper
                .GetComponent<Rigidbody>()
                //.AddForce(0, flipperImpulse, 0, ForceMode.Impulse);
                .AddForce(new Vector3(0, 0, flipperForce));
        }
    }
}
