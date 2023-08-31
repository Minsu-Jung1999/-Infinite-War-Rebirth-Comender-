using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    UnitCombat unitCombat;
    UnitStat unitstat;
    private void Start()
    {
        unitCombat = GetComponentInParent<UnitCombat>();
        unitstat = GetComponentInParent<UnitStat>();
    }

    public void StartAttack()
    {
        Vector2 rayDirection = transform.right * unitCombat.direction; // ������Ʈ�� ���� �������� x �� ������ ���

        int targetLayer = LayerMask.NameToLayer(unitCombat.targetTag); // Ÿ�� ���̾��� �ε��� ��������
        LayerMask layerMask = 1 << targetLayer; // �ش� ���̾� ����ũ ����

        RaycastHit2D hit = Physics2D.Raycast(transform.position , rayDirection, unitstat.unit_attack_range, layerMask);

        Debug.DrawRay(transform.position, rayDirection * unitstat.unit_attack_range , Color.red); // ���̸� �ð������� ǥ��

        if (hit.transform != null)
        {
            print(transform.parent.name + ": " + hit.transform.name);
            if (hit.transform.tag == unitCombat.targetTag)
            {
                unitCombat.Attack(hit.transform);
            }
            else
            {
                print("target Tag : " + unitCombat.targetTag + " , " + "hit tag : " + hit.transform.gameObject.tag);
            }
        }
    }


}
