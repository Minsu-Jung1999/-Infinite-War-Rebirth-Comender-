using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemManager : MonoBehaviour
{
    [SerializeField] GameObject coinPref;
    [SerializeField] Transform parent;
    public void ItemDrop(int addamount)
    {
        Vector3 spawnPosition = transform.position + Vector3.up * 0.2f; // �ٴڿ��� �ణ ����� �����Ѵ�.
        CoinManager coin = ObjectPolling.SpawnFromPool<CoinManager>(coinPref.name, spawnPosition, parent);
        coin.coinAddAmount = addamount;
    }
}
