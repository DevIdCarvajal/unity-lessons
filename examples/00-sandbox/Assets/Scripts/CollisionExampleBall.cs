using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExampleBall : MonoBehaviour
{
    public Vector3 movement = Vector3.down;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(movement * Time.deltaTime);
    }
}
