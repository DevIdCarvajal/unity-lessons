using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMovements : MonoBehaviour
{
    bool playing = false;

    void Start() {
        gameObject.GetComponent<Animation>().Stop();
    }

    public void ToggleAnimation()
    {
        if(playing) {
            gameObject.GetComponent<Animation>().Stop();
        }
        else {
            gameObject.GetComponent<Animation>().Play();
        }
        
        playing = !playing;
    }
}
