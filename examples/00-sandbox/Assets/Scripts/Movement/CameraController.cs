using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera firstPersonCamera;
    
    [SerializeField]
    Camera thirdPersonCamera;

    // TODO: Audio Listener toggling

    void Start()
    {
        firstPersonCamera = Camera.main;
        firstPersonCamera.enabled = true;

        thirdPersonCamera.enabled = false;
    }

    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            // Change 1PCamera to 3PCamera

            if (firstPersonCamera.enabled)
            {
                thirdPersonCamera.enabled = true;

                firstPersonCamera.enabled = false;
            }
            else // Change 3PCamera to 1PCamera
            {
                thirdPersonCamera.enabled = false;
                
                firstPersonCamera.enabled = true;
            }

            // Ternary version

            // thirdPersonCamera.enabled = firstPersonCamera.enabled ? true : false;
            // firstPersonCamera.enabled = firstPersonCamera.enabled ? false : true;
            
            // Toggle version

            // firstPersonCamera.enabled = !firstPersonCamera.enabled;
            // thirdPersonCamera.enabled = !thirdPersonCamera.enabled;

            // Ternary operator example
            /*
            int numero = 2;

            // string paridad = "";

            // if(numero % 2 == 0) {

            //     paridad = "Par";
            // }
            // else
            // {
            //     paridad = "Impar";
            // }

            string paridad = numero % 2 == 0 ? "Par" : "Impar";
            */
        }
    }
}
