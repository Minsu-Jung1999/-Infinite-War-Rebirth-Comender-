using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Threshold : MonoBehaviour
{

    [SerializeField]
    private EventSystem eventSystem = null;

    [SerializeField]
    private float dragThresholdCM = 0.5f;
    private float inchToCm = 2.54f;


    private void SetDragThreshold()
    {
        if (eventSystem != null)
        {
            eventSystem.pixelDragThreshold = (int)(dragThresholdCM * Screen.dpi / inchToCm);
        }
    }

    void Awake()
    {
        SetDragThreshold();
    }

}
