using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    const float gravity = 9.81f;
    const float jumpHeight = 1.0f;

    float speed = 2.0f;
    float movementY = 0;
    
    CharacterController characterController;
    
    bool onGround = false;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // --------- Movement on ground ---------

        // If running...
        speed = Input.GetKey(KeyCode.LeftShift) ? 4 : 2;

        Vector3 translationX = Input.GetAxis("Horizontal") * transform.right * speed;
        Vector3 translationZ = Input.GetAxis("Vertical") * transform.forward * speed;
        
        // --------- Jump & gravity movement ---------

        onGround = characterController.isGrounded;
        
        // Stop falling on ground
        if (onGround && movementY < 0)
        {
            movementY = 0;
        }

        // Jump impulse
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            movementY += Mathf.Sqrt(jumpHeight * gravity * 2);
        }
        
        // Gravity effect
        movementY -= gravity * Time.deltaTime;

        Vector3 translationY = new Vector3(0, movementY, 0);

        // --------- Do the calculated movement ---------

        Vector3 movement = translationX + translationY + translationZ;
        
        characterController.Move(movement * Time.deltaTime);
    }
}
