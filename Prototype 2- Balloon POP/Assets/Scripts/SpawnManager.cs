using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour{
    //balloon spawning variables
    public GameObject[] balloonPrefabs;

    public float xSpawnRange;
    public float ySpawnPos;

    //Invoke variables
    public float startDelay = 0.5f;
    public float spawnInterval = 1.5f;

    /*balloonPrefabs[0] = RedBalloon;
    balloonPrefabs[1] = GreenBalloon;
    balloonPrefabs[2] = BlueBalloon;*/

    // Start is called before the first frame update
    void Start(){
        InvokeRepeating("SpawnRandomBalloon", startDelay, spawnInterval);
    }

    void Update() {
        
    }

    void SpawnRandomBalloon(){

        //Generate the X spawn position                                                 Place 0 on Z
        Vector3 spawnPos = new Vector3(Random.Range(-xSpawnRange,xSpawnRange), ySpawnPos, 0);

        //Pick a random balloon prefab from the full array list
        int balloonIndex = Random.Range(0, balloonPrefabs.Length);

        //Spawn a random balloon on the X-axis
        Instantiate(balloonPrefabs[balloonIndex], spawnPos, balloonPrefabs[balloonIndex].transform.rotation);
    }
}