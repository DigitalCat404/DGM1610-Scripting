using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBonds : MonoBehaviour
{
    public float topBounds = 30f;
    public float bottomBounds = -20f;

    private ScoreManager scoreManager; //find manager to update score
    private DetectCollisions detectCollision;


    void Start()
    {
        //identify ScoreManager and its Script component
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        //get local DetectCollisions component
        detectCollision = GetComponent<DetectCollisions>();
    }

    void Update()
    {
        //if out of bounds on Z-axis, smite from existence
        if(transform.position.z > topBounds){
            Destroy(gameObject);

        //if UFO gets below, delete and penalize score
        }else if(transform.position.z < bottomBounds){
            Debug.Log(tag + " escaped!");
            
            //decrement score if a UFO escaped
            if(tag == "UFO"){
                scoreManager.DecreaseScore(detectCollision.scoreToGive);
            }

            Destroy(gameObject);
        }
    }
}
