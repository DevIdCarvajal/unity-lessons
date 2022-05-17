using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartActions : MonoBehaviour
{
    Vector3 speed = new Vector3(0, 0.05f, 0);

    bool moving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Estado 1: Dardo quieto
        if( moving == false ) {

            // Cuando (evento)... El jugador pulse la tecla arriba
            if( Input.GetKeyDown( KeyCode.UpArrow ) )
            {
                // Si no he llegado al limite
                if( transform.position.y < 2.1 )
                {
                    transform.position = transform.position + speed;
                }
            }

            // Cuando (evento)... El jugador pulse la tecla abajo
            if( Input.GetKeyDown( KeyCode.DownArrow ) )
            {
                // Si no he llegado al limite
                if( transform.position.y > 1 )
                {
                    transform.position = transform.position - speed;
                }
            }

            // Cuando (evento)... El jugador pulse la tecla Space
            if( Input.GetKeyDown( KeyCode.Space ) )
            {
                moving = true;
            }
        }
        else {
            // Estado 2: Dardo moviendose
            transform.Translate(Vector3.left * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision) {
        //moving = false;
        print("hola!");
    }
}
