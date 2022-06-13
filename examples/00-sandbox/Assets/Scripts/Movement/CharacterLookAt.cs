using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLookAt : MonoBehaviour
{
    [SerializeField]
    bool isLooking = false;

    /* ------------ Example 1: BAD ------------ */

    // float horizontalSpeed = 2.0f;
    // float verticalSpeed = 2.0f;

    /* ------------ Example 2: GOOD ------------ */

    float mouseX = 0;
    float mouseY = 0;
    float sensitivity = 2;

    [SerializeField]
    Transform character;

    void Start()
    {
        
    }

    void Update()
    {
        // Si el jugador hace click izquierdo con el ratón
        if (Input.GetButton("Fire1"))
        {
            isLooking = !isLooking;
        }
        
        if (isLooking)
        {
            /* ------------ Example 1: BAD ------------ */
            
            // float h = horizontalSpeed * Input.GetAxis("Mouse X");
            // float v = verticalSpeed * Input.GetAxis("Mouse Y");

            // transform.Rotate(v, h, 0);

            /* ------------ Example 2: GOOD ------------ */

            mouseX += Input.GetAxis("Mouse X") * sensitivity;
            mouseY -= Input.GetAxis("Mouse Y") * sensitivity;

            //mouseY = Mathf.Clamp(mouseY, -30f, 30f);

            character.localEulerAngles = new Vector3(0, mouseX, 0);
            transform.localEulerAngles = new Vector3(mouseY, 0, 0);
        }
    }
}
