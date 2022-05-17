using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dartboard : MonoBehaviour
{
    public int points = 0;
    public int turn = 1;
    public bool endTurn = false;
    public GameObject dartPrefab;

    Vector3 dartPosition = new Vector3(0, 1.8f, -8.75f);
    Quaternion dartRotation = Quaternion.Euler(0, 90, 0);

    void Start()
    {
        
    }

    void Update()
    {
        if( endTurn == true )
        {
            if( Input.GetKeyDown( KeyCode.Space ) )
            {
                Instantiate(dartPrefab, dartPosition, dartRotation);

                endTurn = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        points++;
        turn++;
        endTurn = true;

        print("Tienes " + points + " puntos!!!");
        print("Pulsa Espacio para un nuevo dardo");
    }
}
