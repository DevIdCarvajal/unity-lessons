using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera firstPersonCamera;
    
    [SerializeField]
    Camera thirdPersonCamera;

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
            if (firstPersonCamera.enabled)
            {
                thirdPersonCamera.enabled = true;

                firstPersonCamera.enabled = false;
            }
            else
            {
                thirdPersonCamera.enabled = false;
                
                firstPersonCamera.enabled = true;
            }

            // Ternary!!
        }
    }
}
