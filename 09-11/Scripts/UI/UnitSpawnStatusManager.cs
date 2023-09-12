using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawnStatusManager : MonoBehaviour
{
    public float learpTime;
    public GameObject statuspannel;

    public bool show;
    private float currentTime;
    
    public void OnSpawnStatusButton()
    {
        // true 이면 false로 false 이면 true로 전환
        show = !show;
        currentTime = 0;
    }

    private void Update()
    {
        if(show)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    private void Close()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= learpTime)
        {
            currentTime = learpTime;
        }

        float t = currentTime / learpTime;

        t = t * t * t * (t * (6f * t - 15f) + 10f);

        Vector3 endPosition = new Vector3(-1232f, statuspannel.transform.position.y, 0);
        statuspannel.transform.position = Vector3.Lerp(statuspannel.transform.position, endPosition, t);
    }

    private void Open()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= learpTime)
        {
            currentTime = learpTime;
        }
        float t = currentTime / learpTime;

        t = t * t * t * (t * (6f * t - 15f) + 10f);

        Vector3 endPosition = new Vector3(0, statuspannel.transform.position.y, 0);
        statuspannel.transform.position = Vector3.Lerp(statuspannel.transform.position, endPosition, t);

    }
}
