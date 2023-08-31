using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject spordUnitPrefab;
    [SerializeField] GameObject archerUnitPrefab;
    [SerializeField] GameObject magicienUnitPrefab;

    [Header("Enemy")]
    [SerializeField] GameObject enemyUnitPrefab;

    [Header("SpawnPosition")]
    [SerializeField] GameObject playerUnistSpawner;
    [SerializeField] GameObject enemyUnistSpawner;

    public void SpawnSwordUnit()
    {
        Instantiate(spordUnitPrefab, playerUnistSpawner.transform.position, Quaternion.identity);
    }
    public void SpawnMagicienUnit()
    {
        Instantiate(magicienUnitPrefab, playerUnistSpawner.transform.position, Quaternion.identity);
    }

    public void SpawnArcherUnit()
    {
        Instantiate(archerUnitPrefab, playerUnistSpawner.transform.position, Quaternion.identity);
    }

    public void SpawnEnemyUnit()
    {
        Instantiate(enemyUnitPrefab, enemyUnistSpawner.transform.position, Quaternion.identity);
    }
}
