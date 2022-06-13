using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLookAt : MonoBehaviour
{
    [SerializeField]
    private bool isLooking = false;

    /* ------------ Example 1 ------------ */

    float horizontalSpeed = 2.0f;
    float verticalSpeed = 2.0f;

    /* ------------ Example 2 ------------ */

    // float mouseX = 0;
    // float mouseY = 0;
    // float sensitivity = 2;

    // [SerializeField]
    // private Transform character;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (!isLooking)
            {
                isLooking = true;
            }
            else
            {
                isLooking = false;
            }
        }
        
        if (isLooking)
        {
            /* ------------ Example 1 ------------ */
            
            float h = horizontalSpeed * Input.GetAxis("Mouse X");
            float v = verticalSpeed * Input.GetAxis("Mouse Y");

            transform.Rotate(v, h, 0);
            // transform.Rotate(0, h, 0);

            /* ------------ Example 2 ------------ */

            // mouseX += Input.GetAxis("Mouse X") * sensitivity;
            // mouseY -= Input.GetAxis("Mouse Y") * sensitivity;

            // //mouseY = Mathf.Clamp(mouseY, -30f, 30f);

            // transform.localEulerAngles = new Vector3(mouseY, 0, 0);
            // character.localEulerAngles = new Vector3(0, mouseX, 0);
        }
    }
}
