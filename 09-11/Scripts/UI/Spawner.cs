using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    [Header("Resources Manager")]
    [SerializeField] ResourcesManager rm;

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

    [Header("Shielder")]
    [SerializeField] GameObject shielderUnitPrefab;
    [SerializeField] Transform shielderParent;

    [Header("Enemy")]
    [SerializeField] GameObject skeletonPrefab;
    [SerializeField] Transform skeletonParent;

    [Header("SpawnPosition")]
    [SerializeField] GameObject playerUnistSpawner;
    [SerializeField] GameObject enemyUnistSpawner;

    public void SpawnSwordUnit()
    {
        UnitSpawn(swordUnitPrefab, playerUnistSpawner, swordParent);
    }
    
    public void SpawnMagicienUnit()
    {
        UnitSpawn(magicianUnitPrefab, playerUnistSpawner, magicianParent);
    }
    
    public void SpawnArcherUnit()
    {
        UnitSpawn(archerUnitPrefab, playerUnistSpawner, archerParent);
    }

    public void SpawnEnemyUnit()
    {
        UnitSpawn(skeletonPrefab, enemyUnistSpawner, skeletonParent);
    }

    public void SpawnShilderUnit()
    {
        UnitSpawn(shielderUnitPrefab, playerUnistSpawner, shielderParent);
    }

    private void UnitSpawn(GameObject unit, GameObject spawner, Transform parent)
    {
        UnitCombat unitcombat = unit.GetComponent<UnitCombat>();
        //if(rm.money >= unitcombat.GetCurrentCost())
            ObjectPolling.SpawnFromPool<UnitCombat>(unit.name, spawner.transform.position, parent);

    }

}
