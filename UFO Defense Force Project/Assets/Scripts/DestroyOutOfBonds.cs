using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBonds : MonoBehaviour
{
    public float topBounds = 30f;
    public float bottomBounds = -20f;


    void Awake()
    {
        //Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if out of bounds on Z-axis, smite from existence
        if(transform.position.z > topBounds){
            Destroy(gameObject);

        //if UFO gets below, penalize   
        }else if(transform.position.z < bottomBounds){
            Debug.Log("Game over!");
            Destroy(gameObject);
            //Time.timeScale = 0;
        }
    }
}
