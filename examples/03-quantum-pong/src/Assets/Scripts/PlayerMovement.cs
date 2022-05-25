using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public float speed = 5;
    public int score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if( Input.GetKey( up ) && transform.position.y < 8.5 )
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if( Input.GetKey( down ) && transform.position.y > 1.5 )
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter(Collider ball)
    {
        ball.gameObject.GetComponent<BallMovement>().speedX *= -1.2f;

        gameObject.GetComponent<AudioSource>().Play();
    }
}
