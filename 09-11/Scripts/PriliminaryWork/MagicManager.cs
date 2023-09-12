using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour
{
    float max_timer=1;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= max_timer)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        ObjectPolling.ReturnToPool(gameObject);
    }
}
