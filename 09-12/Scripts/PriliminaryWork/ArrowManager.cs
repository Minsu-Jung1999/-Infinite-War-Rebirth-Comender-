using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowManager : MonoBehaviour
{
    UnitCombat unitcomb;

    private void Start()
    {
        // 좋지 않은 방법
        if (transform.tag == "Player_Armo")
            unitcomb = GameObject.Find("Archer").GetComponent<UnitCombat>();
        else if (transform.tag== "Enemy_Armo")
            unitcomb = GameObject.Find("Skeleton_Archer").GetComponent<UnitCombat>();

    }
    // Update is called once per frame
    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity * -unitcomb.direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == unitcomb.targetTag)
        {
            unitcomb.Attack(collision.transform);
            gameObject.SetActive(false);
        }
        else if (collision.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        ObjectPolling.ReturnToPool(gameObject);
    }
}
