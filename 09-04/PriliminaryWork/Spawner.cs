using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject swordUnitPrefab;
    [SerializeField] GameObject archerUnitPrefab;
    [SerializeField] GameObject magicienUnitPrefab;

    [Header("Enemy")]
    [SerializeField] GameObject skeletonPrefab;

    [Header("SpawnPosition")]
    [SerializeField] Vector2 playerUnistSpawner;
    [SerializeField] Vector2 enemyUnistSpawner;

    public void SpawnSwordUnit()
    {
        print("Sowrd unit name : " + swordUnitPrefab.name);
        ObjectPolling.SpawnFromPool<UnitCombat>(swordUnitPrefab.name, playerUnistSpawner);
    }
    public void SpawnMagicienUnit()
    {
        ObjectPolling.SpawnFromPool<UnitCombat>(magicienUnitPrefab.name, playerUnistSpawner);
    }

    public void SpawnArcherUnit()
    {
        ObjectPolling.SpawnFromPool<UnitCombat>(archerUnitPrefab.name, playerUnistSpawner);
    }

    public void SpawnEnemyUnit()
    {
        ObjectPolling.SpawnFromPool<UnitCombat>(skeletonPrefab.name, enemyUnistSpawner);
    }
}
