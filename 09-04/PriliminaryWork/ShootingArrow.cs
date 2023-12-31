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

    public void Fire()
    {
        if (target == null) return;
        print(target);
        // 화살을 바닥에서 조금 띄워서 스폰한다.
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        GameObject arrow = Instantiate(arrowPrefab, spawnPosition, Quaternion.identity, transform);

        arrow.GetComponent<Rigidbody2D>().velocity = new Vector3((( target.position.x - transform.position.x ) / 2), shootingHeight, 1) * shootingVelocity;
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
