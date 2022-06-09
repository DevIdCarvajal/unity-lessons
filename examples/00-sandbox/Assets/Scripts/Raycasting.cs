using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    Ray ray;
    
    void Start()
    {
        
    }

    void Update()
    {
        ray = new Ray(transform.position, transform.position);
        Debug.DrawRay(ray.origin, ray.direction * 1000);
    }
}
