using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSensor : MonoBehaviour
{
    UnitCombat unitCombat;
    BoxCollider2D box;
    private void Start()
    {
        unitCombat = GetComponentInParent<UnitCombat>();
        print(unitCombat.targetTag);
        box = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == unitCombat.targetTag)
        {
            print("collisionList : " + collision.gameObject.name);
            unitCombat.Attack(collision.transform);
            box.enabled = false;    
        }
    }

    
}
