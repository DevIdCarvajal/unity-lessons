using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    // ESTADOS
    public bool flying = false;
    public bool inDartboard = false;

    // DESPLAZAMIENTO
    Vector3 speedX = new Vector3(0.1f, 0, 0);
    Vector3 speedY = new Vector3(0, 0.1f, 0);
    float speedZ = 1.5f;
    
    void Start()
    {
        
    }

    void Update()
    {
        // Si el dardo no ha sido lanzado
        if( flying == false )
        {
            // Cuando se pulse la tecla arriba
            if( Input.GetKeyDown( KeyCode.UpArrow ) )
            {
                // Si no se sale del límite superior
                if( transform.position.y < 2.3 )
                {
                    transform.position = transform.position + speedY;
                }
            }

            // Cuando se pulse la tecla abajo
            if( Input.GetKeyDown( KeyCode.DownArrow ) )
            {
                // Si no se sale del límite inferior
                if( transform.position.y > 1.7 )
                {
                    transform.position = transform.position - speedY;
                }
            }

            // Cuando se pulse la tecla izquierda
            if( Input.GetKeyDown( KeyCode.LeftArrow ) )
            {
                // Si no se sale del límite izquierdo
                if( transform.position.x > -0.5 )
                {
                    transform.position = transform.position - speedX;
                }
            }

            // Cuando se pulse la tecla derecha
            if( Input.GetKeyDown( KeyCode.RightArrow ) )
            {
                // Si no se sale del límite derecho
                if( transform.position.x < 0.5 )
                {
                    transform.position = transform.position + speedX;
                }
            }

            // Cuando se pulse la tecla espacop
            if( Input.GetKeyDown( KeyCode.Space ) )
            {
                flying = true;
            }
        }
        else // Si el dardo ha sido lanzado y está volando
        {
            // Si el dardo no ha impactado en la diana
            if( inDartboard == false )
            {
                // Si el dardo no ha sobrepasado el límite lejano
                if( transform.position.z < -3 )
                {
                    transform.Translate(Vector3.left * speedZ * Time.deltaTime);
                }
                else // Si el dardo no impactó en la diana y se fue a lo lejos (falló)
                {
                    // Aumentar el turno (en la diana)
                    GameObject dartboard = GameObject.Find("Dartboard");

                    if (dartboard != null)
                    {
                        dartboard.GetComponent<Dartboard>().turn++;
                        dartboard.GetComponent<Dartboard>().endTurn = true;
                    }
                    
                    print("Oh no, has fallado!!");
                    print("Pulsa Espacio para un nuevo dardo");

                    // Desaparecer
                    Destroy(gameObject);
                }
            }
        }
    }

    // Al colisionar
    void OnCollisionEnter(Collision collision)
    {
        // Dardo en la diana
        inDartboard = true;
    }
}
