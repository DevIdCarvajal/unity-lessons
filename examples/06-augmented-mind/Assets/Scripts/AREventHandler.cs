using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class AREventHandler : MonoBehaviour
{
    [SerializeField]
    TMP_Text DebugText;

    [SerializeField]
    TMP_Text ButtonText;

    ARPlaneManager planeManager;
    bool visible = true;

    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
    }

    void OnEnable()
    {
        // Event handling (binding)
        planeManager.planesChanged += OnPlanesChanged;
    }

    void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }

    public void TogglePlanes()
    {
        visible = !visible;

        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(visible);
        }

        ButtonText.text = visible ? "ON" : "OFF";
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        int newPlanes = 0;
        int totalPlanes = 0;

        /*
        foreach (var plane in planeManager.trackables)
        {
            totalPlanes++;
        }
        */
        totalPlanes = planeManager.trackables.count;

        /*
        foreach (var plane in eventArgs.added)
        {
            newPlanes++;
        }
        */
        newPlanes = eventArgs.added.Count;

        DebugText.text = "Nuevos: " + newPlanes + " Totales: " + totalPlanes;
    }
}
