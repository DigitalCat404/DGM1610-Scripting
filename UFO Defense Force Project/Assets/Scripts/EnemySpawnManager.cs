using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    //make private variable visible and editable in builder, Serialize
    [SerializeField]
    private float spawnRangeX = 22.5f;
    [SerializeField]
    private float spawnPosZ = 24f;

    private float startDelay = 2f;
    private float spawnInterval = 2f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    void SpawnRandomEnemy(){
        //Generate a position to spawn at, with random X
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        //pick a random enemy type
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
    
        //Spawn the enemy selected
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
