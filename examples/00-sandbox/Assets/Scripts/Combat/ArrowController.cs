using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;

        if (target.CompareTag("Targetable"))
        {
            /* Solution 1: Parenting */
            /*
            // Non physics
            GetComponent<Rigidbody>().isKinematic = true;

            // Set parent (dartboard)
            transform.parent = target.transform;
            */

            /* Solution 2: Joints */
            FixedJoint joint = gameObject.AddComponent<FixedJoint>() as FixedJoint;

            joint.connectedBody = target.GetComponent<Rigidbody>();
            //joint.breakForce = 10;

            //Destroy(GetComponent<FixedJoint>(), 3);
            //Destroy(gameObject, 6);
        }
    }
}
