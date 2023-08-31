using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSensor : MonoBehaviour
{
    UnitCombat unitCombat;
    private void Start()
    {
        unitCombat = GetComponentInParent<UnitCombat>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == unitCombat.targetTag)
        {
            unitCombat.Attack(collision.transform);
        }
    }

    
}
