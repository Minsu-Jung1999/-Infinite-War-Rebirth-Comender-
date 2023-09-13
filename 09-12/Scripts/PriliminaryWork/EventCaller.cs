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
        print(transform.name + " : " + hit.transform.name);
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
        Vector2 rayDirection = transform.right * unitCombat.direction; // 오브젝트의 정면 방향으로 x 축 방향을 사용

        int targetLayer = LayerMask.NameToLayer(unitCombat.targetTag); // 타겟 레이어의 인덱스 가져오기
        LayerMask layerMask = 1 << targetLayer; // 해당 레이어 마스크 생성

        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, layerMask);
        if (hit.collider != null)
        {
            // 레이가 어떤 객체와 충돌했을 때 실행될 코드
            Debug.Log(transform.parent.name + "의 레이가 " + hit.collider.name + "과(와) 충돌했습니다.");
        }
        else
        {
            // 충돌하지 않았을 때 실행될 코드
            Debug.Log(transform.parent.name + "의 레이가 어떤 객체와도 충돌하지 않았습니다.");
        }

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
    }


    private void MagicSpawn(Vector3 spawnPosition)
    {
        ObjectPolling.SpawnFromPool(lightning.name, spawnPosition, parent);
    }
}
