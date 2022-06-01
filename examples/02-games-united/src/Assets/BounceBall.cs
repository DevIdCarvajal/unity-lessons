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
        rigidBall
            .GetComponent<Rigidbody>()
            .AddForce(strike.contacts[0].normal * 3000, ForceMode.Impulse);
    }
}
