using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private void OnEnable()
    {
        Debug.Log("Spawn");
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Hello");
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        ObjectPolling.ReturnToPool(gameObject);
    }
}
