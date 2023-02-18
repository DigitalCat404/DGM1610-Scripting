using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    //in case more pickups are added, futureproofed with array
    public GameObject[] pickupPrefabs;

    //make private variable visible and editable in builder, Serialize
    [SerializeField]
    private float spawnRangeX = 22.5f;
    [SerializeField]
    private float spawnPosZ = 24f;

    private float startDelay = 2f;
    private float spawnInterval = 2f;

    private float pickupDelay = 5f;
    private float pickupInterval = 15f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
        InvokeRepeating("SpawnPickup", pickupDelay, pickupInterval);
    }

    void SpawnRandomEnemy(){
        //Generate a position to spawn at, with random X
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        //pick a random enemy type
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
    
        //Spawn the enemy selected
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }

    void SpawnPickup(){
        //Generate a position to spawn at, with random X
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
    
        //Spawn the pickup
        Instantiate(pickupPrefabs[0], spawnPos, pickupPrefabs[0].transform.rotation);
    }
}
