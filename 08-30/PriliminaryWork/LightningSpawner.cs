using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpawner : MonoBehaviour
{

    [SerializeField] GameObject lightningPrefab;
    [SerializeField] Vector3 target;
    UnitCombat unitcombat;
     
    private void Start()
    {
        unitcombat = GetComponentInParent<UnitCombat>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == unitcombat.targetTag)
        {
            target = collision.transform.position;
        }
    }

    public void SpawnMagic()
    {
        GameObject magic = Instantiate(lightningPrefab, target ,Quaternion.identity,transform);
        Destroy(magic,1f);
    }

}
