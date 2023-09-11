using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] float height;
    [SerializeField] float duration;
    UnitCombat unitcomb;
    private void Start()
    {
        // unitcomb = GetComponentInParent<UnitCombat>();
        unitcomb = GameObject.Find("Archer").GetComponent<UnitCombat>();
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
