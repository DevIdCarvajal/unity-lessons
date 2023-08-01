using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dartboard : MonoBehaviour
{
    // ESTADOS
    public int points = 0;
    public int turn = 1;
    public bool endTurn = false;

    // DATOS DE INSTANCIACIÓN DE NUEVO DARDO
    public GameObject dartPrefab;
    Vector3 dartPosition = new Vector3(0, 1.8f, -8.75f);
    Quaternion dartRotation = Quaternion.Euler(0, 90, 0);

    void Start()
    {
        
    }

    void Update()
    {
        // Si se acabó el turno
        if( endTurn == true )
        {
            // Si se pulsa la tecla espacio
            if( Input.GetKeyDown( KeyCode.Space ) )
            {
                // Instanciar objeto
                Instantiate(dartPrefab, dartPosition, dartRotation);

                // Acabar el turno
                endTurn = false;
            }
        }
    }

    // Al colisionar
    void OnCollisionEnter(Collision collision)
    {
        // Aumentar puntos, aumentar el turno y acabar el turno
        points++;
        turn++;
        endTurn = true;

        print("Tienes " + points + " puntos!!!");
        print("Pulsa Espacio para un nuevo dardo");
    }
}
