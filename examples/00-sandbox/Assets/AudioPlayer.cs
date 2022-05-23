using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public bool playing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMusic()
    {
        //if (playing == false)
        //if (playing != true)
        if (!playing)
        {
            // Acceder a la cámara
            GameObject camera = GameObject.Find("Main Camera");
            camera.GetComponent<AudioSource>().Play();

            // Cambiar el texto del botón
            //GameObject myTextObject = GameObject.Find("Canvas/Button/Text");
            //myTextObject.GetComponent<UnityEngine.UI.Text>().text = "Stop Music";

            //Text myText = GameObject.Find("Canvas/Button/Text").GetComponent<Text>();
            //myText.text = "Stop Music";
            //myText.fontStyle = ... ;

            //GameObject.Find("Canvas/Button/Text").GetComponent<Text>().text = "Stop Music";

            playing = true;
        }
        else
        {
            GameObject camera = GameObject.Find("Main Camera");
            camera.GetComponent<AudioSource>().Stop();

            //Text myText = GameObject.Find("Canvas/Button/Text").GetComponent<Text>();
            //myText.text = "Play Music";

            playing = false;
        }
    }
}
