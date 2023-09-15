using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCaller : MonoBehaviour
{
    ShootingArrow shot;
    [Header("For Magicien")]
    [SerializeField] GameObject lightning;
    [SerializeField] Transform parent;

    UnitCombat unitCombat;

    private void Start()
    {
        unitCombat = GetComponentInParent<UnitCombat>();
        shot = GetComponentInParent<ShootingArrow>();
    }

    public void StartAttack()
    {
        RaycastHit2D hit = ShootingRay();
        if (hit.transform != null)
        {
            if (hit.transform.tag == unitCombat.targetTag)
            {
                if (unitCombat.WeaponType() == 2)
                    MagicSpawn(hit.transform.position);
                unitCombat.Attack(hit.transform);
            }
        }
        else
        {
            unitCombat.AttackCancel();
        }
    }

    private RaycastHit2D ShootingRay()
    {
        Vector2 rayDirection = transform.right * unitCombat.direction; // ������Ʈ�� ���� �������� x �� ������ ���
        Vector3 rayStartPosition = transform.position + (Vector3.up * 0.2f);

        int targetLayer = LayerMask.NameToLayer(unitCombat.targetTag); // Ÿ�� ���̾��� �ε��� ��������
        LayerMask layerMask = 1 << targetLayer; // �ش� ���̾� ����ũ ����

        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, rayDirection, unitCombat.GetCurrentAttackRange(), layerMask);
        

        Debug.DrawRay(transform.position, rayDirection * unitCombat.GetCurrentAttackRange(), Color.red); // ���̸� �ð������� ǥ��     ******** ��� �� ����
        return hit;
    }

    public void Shotting()
    {
        shot.Fire();
    }

    public void Die()
    {
        unitCombat.Die();
    }


    private void MagicSpawn(Vector3 spawnPosition)
    {
        ObjectPolling.SpawnFromPool(lightning.name, spawnPosition, parent);
    }
}