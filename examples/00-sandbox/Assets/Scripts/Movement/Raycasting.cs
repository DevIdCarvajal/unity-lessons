using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    Ray ray;

    void Start()
    {
        // Creates a Ray from the character to forward
        // ray = new Ray(transform.position, transform.forward);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ray = new Ray(transform.position, transform.forward);

            RaycastHit hitData;

            // If the Ray hit something...
            if (Physics.Raycast(ray, out hitData))
            {
                // Debug.Log(hitPosition);
                // Debug.Log(hitDistance);

                if (hitData.collider.tag == "Destructible")
                {                    
                    Destroy(hitData.transform.gameObject);
                }
            }
            
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
        }
    }
}
