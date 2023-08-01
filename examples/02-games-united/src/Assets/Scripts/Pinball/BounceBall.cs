using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour
{
    public GameObject rigidBall;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision strike)
    {
        Debug.DrawRay(
            strike.contacts[0].point,
            -strike.contacts[0].normal * 5,
            Color.magenta
        );

        rigidBall
            .GetComponent<Rigidbody>()
            .AddForce(-strike.contacts[0].normal * 50);
    }
}
