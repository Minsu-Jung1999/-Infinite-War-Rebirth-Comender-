using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootingArrow : MonoBehaviour
{
    UnitCombat unitcombat;
    Transform target;
    [SerializeField] float shootingHeight;
    [SerializeField] float shootingVelocity;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform arrowParent;

    private void Start()
    {
        unitcombat = GetComponent<UnitCombat>();
    }

    public void Fire()
    {
        if (target == null)
        {
            print("Tart is null");
            unitcombat.AttackCancel();
        }
        else
        {
            // ȭ���� �ٴڿ��� ���� ����� �����Ѵ�.
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

            Transform arrow = ObjectPolling.SpawnFromPool<Transform>(arrowPrefab.name, spawnPosition, arrowParent);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector3(((target.position.x - transform.position.x) / 2), shootingHeight, 1) * shootingVelocity;
            print("Target is : " + target.name);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == unitcombat.targetTag)
        {
            target = collision.transform;
        }
    }

    public Vector3 GetTarget()
    {
        return target.position;
    }

 

}
