using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExampleWall : MonoBehaviour
{
    public AudioSource beep;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {   
        // Reproducir sonido
        beep.Play();

        // Decirle al otro objeto que se mueva a la derecha
        other.gameObject.GetComponent<CollisionExampleBall>().movement = Vector3.right;

        /*
        CollisionExampleBall otherScript;

        otherScript = other.gameObject.GetComponent<CollisionExampleBall>();

        if (otherScript != null)
        {
            otherScript.movement = Vector3.right;
        }
        else {
            // Handle error
        }
        */
    }

    /*void OnCollisionEnter(Collision collision)
    {
        // collision....

        collision.gameObject.GetComponent<CollisionExampleBall>().movement = Vector3.right;
    }*/
}
