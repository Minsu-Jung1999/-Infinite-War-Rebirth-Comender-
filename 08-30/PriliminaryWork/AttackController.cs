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
        Vector2 rayDirection = transform.right * unitCombat.direction; // 오브젝트의 정면 방향으로 x 축 방향을 사용

        int targetLayer = LayerMask.NameToLayer(unitCombat.targetTag); // 타겟 레이어의 인덱스 가져오기
        LayerMask layerMask = 1 << targetLayer; // 해당 레이어 마스크 생성

        RaycastHit2D hit = Physics2D.Raycast(transform.position , rayDirection, unitstat.unit_attack_range, layerMask);

        Debug.DrawRay(transform.position, rayDirection * unitstat.unit_attack_range , Color.red); // 레이를 시각적으로 표시

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
