using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSensor : MonoBehaviour
{
    UnitCombat unitcombat;
    private void Start()
    {
        unitcombat = GetComponentInParent<UnitCombat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == unitcombat.targetTag)
        {
            unitcombat.Attack(collision.transform);
            print(collision.name);
        }
    }

}
