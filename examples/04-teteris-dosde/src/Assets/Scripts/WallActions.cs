using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallActions : MonoBehaviour
{
    public GameObject gameLogic;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider; // Get shape collider
        Vector3 contactPoint = collision.contacts[0].point; // Get collision point
        Vector3 centerShape = collider.bounds.center; // Get shape center

        if (contactPoint.x < centerShape.x) // Left wall
        {
            gameLogic.GetComponent<GameLogic>().leftLimit = true;
        }
        else // (contactPoint.x > centerShape.x) // Right wall
        {
            gameLogic.GetComponent<GameLogic>().rightLimit = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        gameLogic.GetComponent<GameLogic>().leftLimit = false;
        gameLogic.GetComponent<GameLogic>().rightLimit = false;
    }
}