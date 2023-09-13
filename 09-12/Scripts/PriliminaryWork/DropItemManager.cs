using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemManager : MonoBehaviour
{
    [SerializeField] GameObject coinPref;
    [SerializeField] Transform parent;
    public void ItemDrop()
    {
        if(transform.CompareTag("Enemy"))
        {
            Vector3 spawnPosition = transform.position + Vector3.up * 0.2f; // 바닥에서 약간 띄워서 생성한다.
            ObjectPolling.SpawnFromPool(coinPref.name, spawnPosition, parent);
        }
    }
}
