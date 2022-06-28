using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    float speed = 10.0f;
    float gravity = -9.81f;
    Vector3 velocity = new Vector3(0, 0, 0);

    float groundDistance = 0.4f;
    bool isGrounded;
    LayerMask floorMask = 1<<12;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    CharacterController characterController;

    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(3 * -2 * gravity);
        }

        float translationX = Input.GetAxis("Horizontal");
        float translationZ = Input.GetAxis("Vertical");

        Vector3 move =
            (transform.right * translationX) +  // Horizontal movement
            (transform.forward * translationZ); // Vertical movement
        
        characterController.Move(move * speed * Time.deltaTime);

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
