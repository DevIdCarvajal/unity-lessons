using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    public bool flying = false;
    public bool inDartboard = false;
    public float speedZ = 1.5f;

    Vector3 speedX = new Vector3(0.1f, 0, 0);
    Vector3 speedY = new Vector3(0, 0.1f, 0);
    
    void Start()
    {
        
    }

    void Update()
    {
        if( flying == false )
        {
            if( Input.GetKeyDown( KeyCode.UpArrow ) )
            {
                if( transform.position.y < 2.3 )
                {
                    transform.position = transform.position + speedY;
                }
            }

            if( Input.GetKeyDown( KeyCode.DownArrow ) )
            {
                if( transform.position.y > 1.7 )
                {
                    transform.position = transform.position - speedY;
                }
            }

            if( Input.GetKeyDown( KeyCode.LeftArrow ) )
            {
                if( transform.position.x > -0.5 )
                {
                    transform.position = transform.position - speedX;
                }
            }

            if( Input.GetKeyDown( KeyCode.RightArrow ) )
            {
                if( transform.position.x < 0.5 )
                {
                    transform.position = transform.position + speedX;
                }
            }

            if( Input.GetKeyDown( KeyCode.Space ) )
            {
                flying = true;
            }
        }
        else {
            if( inDartboard == false )
            {
                if( transform.position.z < -3 )
                {
                    transform.Translate(Vector3.left * speedZ * Time.deltaTime);
                }
                else
                {
                    GameObject dartboard = GameObject.Find("Dartboard");

                    if (dartboard != null)
                    {
                        dartboard.GetComponent<Dartboard>().turn++;
                        dartboard.GetComponent<Dartboard>().endTurn = true;
                    }
                    
                    print("Oh no, has fallado!!");
                    print("Pulsa Espacio para un nuevo dardo");

                    Destroy(gameObject);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        inDartboard = true;
    }
}
