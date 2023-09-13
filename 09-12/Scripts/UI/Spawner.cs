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

    [Header("Skeleton")]
    [SerializeField] GameObject skeletonPrefab;
    [SerializeField] Transform skeletonParent;

    [Header("Skeleton_Archer")]
    [SerializeField] GameObject skeletonArcherPrefab;
    [SerializeField] Transform skeletonArcherParent;

    [Header("Skeleton_Dagger")]
    [SerializeField] GameObject skeletonDaggerPrefab;
    [SerializeField] Transform skeletonDaggerParent;

    [Header("SpawnPosition")]
    [SerializeField] GameObject playerUnistSpawner;
    [SerializeField] GameObject enemyUnistSpawner;


    #region PlayerUnits
    public void SpawnSwordUnit()
    {
        UnitSpawn(swordUnitPrefab, playerUnistSpawner, swordParent);
    }

    public void SpawnArcherUnit()
    {
        UnitSpawn(archerUnitPrefab, playerUnistSpawner, archerParent);
    }

    public void SpawnMagicienUnit()
    {
        UnitSpawn(magicianUnitPrefab, playerUnistSpawner, magicianParent);
    }

    public void SpawnShilderUnit()
    {
        UnitSpawn(shielderUnitPrefab, playerUnistSpawner, shielderParent);
    }
    #endregion


    #region EnemyUnits
    public void SpawnSkeletonUnit()
    {
        UnitSpawn(skeletonPrefab, enemyUnistSpawner, skeletonParent);
    }

    public void SpawnSkeletonArcherUnit()
    {
        UnitSpawn(skeletonArcherPrefab, enemyUnistSpawner, skeletonArcherParent);
    }

     public void SpawnSkeletonDaggerUnit()
    {
        UnitSpawn(skeletonDaggerPrefab, enemyUnistSpawner, skeletonDaggerParent);
    }

    #endregion


    private void UnitSpawn(GameObject unit, GameObject spawner, Transform parent)
    {
        UnitCombat unitcombat = unit.GetComponent<UnitCombat>();
        //if(rm.money >= unitcombat.GetCurrentCost())
            ObjectPolling.SpawnFromPool<UnitCombat>(unit.name, spawner.transform.position, parent);

    }

}
