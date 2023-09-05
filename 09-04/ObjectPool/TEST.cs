using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            ObjectPolling.SpawnFromPool<Bullet>("Circle", Vector2.zero);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ObjectPolling.SpawnFromPool<Bullet>("Hexagon", Vector2.zero);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ObjectPolling.SpawnFromPool<Bullet>("Square", Vector2.zero);
        }
    }
}
