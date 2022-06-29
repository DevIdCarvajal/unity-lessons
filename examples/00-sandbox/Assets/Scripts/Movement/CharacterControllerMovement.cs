using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    const float gravity = -9.81f;

    float speed = 2.0f;
    float jumpHeight = -350.0f;

    bool onGround = false;
    
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // --------- Movement horizontal & vertical ---------

        Vector3 translationX = Input.GetAxis("Horizontal") * transform.right;
        Vector3 translationZ = Input.GetAxis("Vertical") * transform.forward;
        
        Vector3 move = translationX + translationZ;
        
        // --------- Jump & gravity movement ---------

        onGround = characterController.isGrounded;
        
        if (onGround && move.y < 0)
        {
            move.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            move.y += Mathf.Sqrt(jumpHeight * gravity * Time.deltaTime);
        }
        
        move.y += gravity * Time.deltaTime;

        // --------- Do the calculated movement ---------
        characterController.Move(move * speed * Time.deltaTime);
    }
}
