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
        unitcomb = GetComponentInParent<UnitCombat>();
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == unitcomb.targetTag)
        {
            unitcomb.Attack(collision.transform);
            Destroy(gameObject);
        }
        else if (collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
