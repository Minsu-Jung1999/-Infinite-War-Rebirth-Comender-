using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    List<GameObject> target;

    [SerializeField] float speed;
    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Player"))
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        else if (gameObject.CompareTag("Enemy"))
            enemy = GameObject.FindGameObjectWithTag("Player");
        else
        {
            print(gameObject.name + " There is no enemy exist in the game");
            enemy = null;
        }


        print(gameObject.name + " Enemy is " + enemy.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
