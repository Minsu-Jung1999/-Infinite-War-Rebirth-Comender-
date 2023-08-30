using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject playerUnitPrefab;
    [SerializeField] GameObject archerUnitPrefab;
    [SerializeField] GameObject enemyUnitPrefab;

    [SerializeField] GameObject playerUnistSpawner;
    [SerializeField] GameObject enemyUnistSpawner;

    public void SpawnPlayerUnit()
    {
        Instantiate(playerUnitPrefab, playerUnistSpawner.transform.position, Quaternion.identity);
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
