using UnityEngine;
using TMPro;
using System;

public class CharacterLookAt : MonoBehaviour
{
    [SerializeField]
    bool isLooking = false;

    [SerializeField]
    Transform character;
    
    [SerializeField]
    TMP_Text debugPanelText;

    float mouseX = 0;
    float mouseY = 0;
    float sensitivity = 2;

    Ray ray;

    void Start()
    {
        // Creates a Ray from the character to forward
        //ray = new Ray(transform.position, transform.forward);
    }

    void Update()
    {
        // Toggle between first/third person cameras
        if (Input.GetButton("Fire1"))
        {
            isLooking = !isLooking;
        }
        
        if (isLooking)
        {
            // Horizontal look
            if(Input.mousePosition.x < 10) // Left limit
            {
                mouseX -= sensitivity;
            }
            else
            if(Input.mousePosition.x > Screen.width-10) // Right limit
            {
                mouseX += sensitivity;
            }
            else // Between limits
            {
                mouseX += Input.GetAxis("Mouse X") * sensitivity;
            }

            // Vertical look
            mouseY -= Input.GetAxis("Mouse Y") * sensitivity;
            //mouseY = Mathf.Clamp(mouseY, -30f, 30f);

            // Update camera
            character.localEulerAngles = new Vector3(0, mouseX, 0);
            transform.localEulerAngles = new Vector3(mouseY, 0, 0);

            // ------------------- Debugging -------------------
            // Debug.Log(Screen.width);

            debugPanelText.text =
                "X: " + Input.mousePosition.x +
                " - " +
                "Y: " + Input.mousePosition.y;
        }
        
        // Raycasting
        if(Input.GetKeyDown(KeyCode.R)) {
            // ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ray = new Ray(transform.position, transform.forward);

            // RaycastHit hitData;

            // if (Physics.Raycast(ray, out hitData))
            // {
            //     // The Ray hit something!
            //     print("Shoot!");

            //     // Vector3 hitPosition  = hitData.point;
            //     // float hitDistance    = hitData.distance;
            //     // string targetTag     = hitData.collider.tag;
            //     // GameObject hitObject = hitData.transform.gameObject;

            //     // Debug.Log(hitPosition);
            //     // Debug.Log(hitDistance);
            //     // Debug.Log(targetTag);
            //     // Destroy(hitObject);
            // }

            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
        }
    }
}
