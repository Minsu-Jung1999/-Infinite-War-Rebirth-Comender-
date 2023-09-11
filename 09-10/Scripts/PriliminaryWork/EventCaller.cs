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
        Vector2 rayDirection = transform.right * unitCombat.direction; // 오브젝트의 정면 방향으로 x 축 방향을 사용

        int targetLayer = LayerMask.NameToLayer(unitCombat.targetTag); // 타겟 레이어의 인덱스 가져오기
        LayerMask layerMask = 1 << targetLayer; // 해당 레이어 마스크 생성

        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, unitCombat.GetCurrentAttackRange(), layerMask);

        Debug.DrawRay(transform.position, rayDirection * unitCombat.GetCurrentAttackRange(), Color.red); // 레이를 시각적으로 표시     ******** 출시 시 제거
        return hit;
    }

    public void Shotting()
    {
        shot.Fire();
    }

    public void Die()
    {
        unitCombat.Die();
        //transform.parent.gameObject.SetActive(false);
    }


    private void MagicSpawn(Vector3 spawnPosition)
    {
        ObjectPolling.SpawnFromPool(lightning.name, spawnPosition, parent);
    }
}
