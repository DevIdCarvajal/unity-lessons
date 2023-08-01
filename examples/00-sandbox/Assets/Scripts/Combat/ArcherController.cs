using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    [SerializeField]
    GameObject arrowPrefab;

    [SerializeField]
    Transform arrowOrigin;
    
    int arrows = 10;
    float arrowSpeed = 1500.0f;

    void Update()
    {
        if(arrows > 0) {
            if(Input.GetKeyDown(KeyCode.V)) {

                GameObject newArrow = Instantiate(
                    arrowPrefab,
                    arrowOrigin.position,
                    Quaternion.Euler(arrowOrigin.eulerAngles)
                );

                newArrow
                    .GetComponent<Rigidbody>()
                    .AddForce(newArrow.transform.forward * arrowSpeed);

                //arrows--;
            }
        }
    }
}
