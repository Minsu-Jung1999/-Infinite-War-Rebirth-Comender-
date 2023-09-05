using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCaller : MonoBehaviour
{
    ShootingArrow shot;
    [Header("For Magicien")]
    [SerializeField] GameObject lightning;

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
            print(transform.parent.name + ": " + hit.transform.name);
            if (hit.transform.tag == unitCombat.targetTag)
            {
                if (unitCombat.WeaponType() == 2)
                    MagicSpawn(hit.transform.position);
                unitCombat.Attack(hit.transform);
            }
            else
            {
                print("target Tag : " + unitCombat.targetTag + " , " + "hit tag : " + hit.transform.gameObject.tag);
            }
        }
        else
        {
            print(gameObject.name + ": not hit");
            unitCombat.AttackCancel();
        }
    }

    private RaycastHit2D ShootingRay()
    {
        Vector2 rayDirection = transform.right * unitCombat.direction; // ������Ʈ�� ���� �������� x �� ������ ���

        int targetLayer = LayerMask.NameToLayer(unitCombat.targetTag); // Ÿ�� ���̾��� �ε��� ��������
        LayerMask layerMask = 1 << targetLayer; // �ش� ���̾� ����ũ ����

        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, unitCombat.GetCurrentAR(), layerMask);

        Debug.DrawRay(transform.position, rayDirection * unitCombat.GetCurrentAR(), Color.red); // ���̸� �ð������� ǥ��     ******** ��� �� ����
        return hit;
    }

    public void Shotting()
    {
        print("SHotting!!");
        shot.Fire();
    }

    public void Die()
    {
        transform.parent.gameObject.SetActive(false);
    }

    private void MagicSpawn(Vector3 spawnPosition)
    {
        GameObject magic = Instantiate(lightning, spawnPosition, Quaternion.identity);
        Destroy(magic, 1.0f);
    }
}
