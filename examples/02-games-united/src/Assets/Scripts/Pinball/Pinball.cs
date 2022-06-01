using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public GameObject rigidBall;
    public GameObject rigidLeftFlipper;
    public GameObject rigidRightFlipper;
    //public float ballImpulse = 20f;
    //public float flipperImpulse = 16f;

    public Vector3 ballForce = new Vector3(50, 1200, 0);
    public Vector3 flipperForce = new Vector3(0, 1800, 0);

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
                .AddForce(ballForce);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rigidLeftFlipper
                .GetComponent<Rigidbody>()
                //.AddForce(0, flipperImpulse, 0, ForceMode.Impulse);
                .AddForce(flipperForce);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            rigidRightFlipper
                .GetComponent<Rigidbody>()
                //.AddForce(0, flipperImpulse, 0, ForceMode.Impulse);
                .AddForce(flipperForce);
        }
    }
}
