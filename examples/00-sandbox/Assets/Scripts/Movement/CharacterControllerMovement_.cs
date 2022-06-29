using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement_ : MonoBehaviour
{
    float speed = 2.0f;
    float jumpSpeed = 30.0f;
    float gravity = -9.81f;
    bool onGround = true;
    
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 translationX = Input.GetAxis("Horizontal") * transform.right;
        Vector3 translationZ = Input.GetAxis("Vertical") * transform.forward;Vector3 translationY = new Vector3(0, 0, 0);

        // Jumping
        if ((characterController.collisionFlags & CollisionFlags.Below) != 0)
        {
            onGround = true;
        }
        else {
            onGround = false;
        }
        // controller.isGrounded ?

        // Gravity ??

        if (Input.GetKeyDown(KeyCode.Space))
        {
            translationY += jumpSpeed * transform.up;
            // translationY.y += gravity;
        }

        Vector3 move =
            translationX +  // Horizontal movement
            translationZ + // Vertical movement 
            translationY; // Jumping movement
        
        characterController.Move(move * speed * Time.deltaTime);
    }
}
