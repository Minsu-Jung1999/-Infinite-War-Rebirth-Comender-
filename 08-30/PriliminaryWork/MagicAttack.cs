using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{

    [SerializeField]GameObject lightning;
    
    UnitCombat unitCombat;
    UnitStat unitstat;
    private void Start()
    {
        unitCombat = GetComponentInParent<UnitCombat>();
        unitstat = GetComponentInParent<UnitStat>();
    }

    public void StartAttack()
    {
        Vector2 rayDirection = transform.right; // ������Ʈ�� ���� �������� x �� ������ ���

        int targetLayer = LayerMask.NameToLayer(unitCombat.targetTag); // Ÿ�� ���̾��� �ε��� ��������
        LayerMask layerMask = 1 << targetLayer; // �ش� ���̾� ����ũ ����

        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, unitstat.unit_attack_range, layerMask);

        Debug.DrawRay(transform.position, rayDirection * unitstat.unit_attack_range, Color.red); // ���̸� �ð������� ǥ��

        if (hit.transform != null)
        {
            if (hit.transform.CompareTag(unitCombat.targetTag))
            {
                MagicSpawn(hit.transform.position);
                //unitCombat.Attack(hit.transform);
            }
            else
            {
                print(transform.parent.name + " = target Tag : " + unitCombat.targetTag + " , " + "hit tag : " + hit.transform.gameObject.tag);
            }
        }
    }

    private void MagicSpawn(Vector3 spawnPosition)
    {
        print("Hit");
        GameObject magic = Instantiate(lightning, spawnPosition, Quaternion.identity);
        Destroy(magic,1.0f);
    }
}
