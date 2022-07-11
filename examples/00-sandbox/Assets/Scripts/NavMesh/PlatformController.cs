using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Me cayó algo!!!");

        // TODO: Solo por arriba

        // El objeto que cae encima de mí pasa a ser mi hijo
        collision.gameObject.transform.parent = transform;
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Se fue!!!");

        // El objeto que se va de mí ya no es mi hijo
        collision.gameObject.transform.parent = null;
    }
}
