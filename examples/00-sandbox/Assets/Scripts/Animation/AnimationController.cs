using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // If moving...
        if (Input.GetAxis("Horizontal") != 0 ||
            Input.GetAxis("Vertical") != 0)
        {
            // Animation
            animator.SetBool("isWalking", true);

            // Look
            if (Input.GetAxis("Horizontal") > 0) // Right
            {
                transform.localEulerAngles = new Vector3(0, 90, 0);
            }
            else
            if (Input.GetAxis("Horizontal") < 0) // Left
            {
                transform.localEulerAngles = new Vector3(0, -90, 0);
            }
            else
            if (Input.GetAxis("Vertical") > 0) // Up
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else // Down
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
            }
        }
        else
        {
            // Animation
            animator.SetBool("isWalking", false);
        }
    }

    // One script w/some functions!!
    // handleAnimation()
    // handleRotation()
    // handleGravity()
}
