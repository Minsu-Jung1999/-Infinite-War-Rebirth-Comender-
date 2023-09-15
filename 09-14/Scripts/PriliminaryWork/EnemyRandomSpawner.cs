using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemy;
    [SerializeField] List<Transform> enemy_parent;
    [SerializeField] float coolTime;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnRandomUnit();
    }

    private void SpawnRandomUnit()
    {
        timer += Time.deltaTime;
        if (timer >= coolTime)
        {
            int radomnum = UnityEngine.Random.Range(0, enemy.Count);
            ObjectPolling.SpawnFromPool<UnitCombat>(enemy[radomnum].name, transform.position, enemy_parent[radomnum]);
            timer = 0;
        }
    }
}
