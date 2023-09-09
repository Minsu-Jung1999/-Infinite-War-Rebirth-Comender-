using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Sword")]
    [SerializeField] GameObject swordUnitPrefab;
    [SerializeField] Transform swordParent;

    [Space]
    [Header("Archer")]
    [SerializeField] GameObject archerUnitPrefab;
    [SerializeField] Transform archerParent;

    [Space]
    [Header("Magician")]
    [SerializeField] GameObject magicianUnitPrefab;
    [SerializeField] Transform magicianParent;

    [Header("Enemy")]
    [SerializeField] GameObject skeletonPrefab;
    [SerializeField] Transform skeletonParent;

    [Header("SpawnPosition")]
    [SerializeField] GameObject playerUnistSpawner;
    [SerializeField] GameObject enemyUnistSpawner;

    public void SpawnSwordUnit()
    {
        print("Sowrd unit name : " + swordUnitPrefab.name);
        ObjectPolling.SpawnFromPool<UnitCombat>(swordUnitPrefab.name, playerUnistSpawner.transform.position, swordParent);
    }
    public void SpawnMagicienUnit()
    {
        ObjectPolling.SpawnFromPool<UnitCombat>(magicianUnitPrefab.name, playerUnistSpawner.transform.position,magicianParent);
    }

    public void SpawnArcherUnit()
    {
        ObjectPolling.SpawnFromPool<UnitCombat>(archerUnitPrefab.name, playerUnistSpawner.transform.position, archerParent);
    }

    public void SpawnEnemyUnit()
    {
        ObjectPolling.SpawnFromPool<UnitCombat>(skeletonPrefab.name, enemyUnistSpawner.transform.position, skeletonParent);
    }
}
