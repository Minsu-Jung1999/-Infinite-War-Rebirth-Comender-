using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootingArrow : MonoBehaviour
{
    Transform target;
    [SerializeField] float shootingHeight;
    [SerializeField] float shootingVelocity;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform arrowParent;

    public void Fire()
    {
        if (target == null) return;
        // ȭ���� �ٴڿ��� ���� ����� �����Ѵ�.
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        ObjectPolling.SpawnFromPool<Rigidbody2D>(arrowPrefab.name, spawnPosition, arrowParent).velocity = new Vector3(((target.position.x - transform.position.x) / 2), shootingHeight, 1) * shootingVelocity;

        //arrow.GetComponent<Rigidbody2D>().velocity = new Vector3((( target.position.x - transform.position.x ) / 2), shootingHeight, 1) * shootingVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            target = collision.transform;
        }
    }

    public Vector3 GetTarget()
    {
        return target.position;
    }

 

}
