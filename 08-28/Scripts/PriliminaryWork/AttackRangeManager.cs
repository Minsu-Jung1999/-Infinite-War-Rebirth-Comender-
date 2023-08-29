using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeManager : MonoBehaviour
{
    UnitCombat unitCombat;
    private void Start()
    {
        unitCombat = GetComponentInParent<UnitCombat>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == unitCombat.targetTag)
        {
            unitCombat.AttackCancle();
            print("Exit!!!!!!!!!!");
        }
    }
}
