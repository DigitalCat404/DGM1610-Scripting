using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBonds : MonoBehaviour
{
    public float topBounds = 30f;
    public float bottomBounds = -20f;

    private bool isDeleted = false;

    private ScoreManager scoreManager; //find manager to update score
    private DetectCollisions detectCollision;

    //Audio
    private AudioSource escapeAudio;
    public AudioClip powerUp;


    void Start()
    {
        //identify ScoreManager and its Script component
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        //get local DetectCollisions component
        detectCollision = GetComponent<DetectCollisions>();

        escapeAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //if out of bounds on Z-axis, smite from existence
        if(transform.position.z > topBounds){
            Destroy(gameObject);

        //if UFO gets below, delete and penalize score
        }else if(transform.position.z < bottomBounds){
            
            //decrement score if a UFO escaped
            if(tag == "UFO"){
                if(!isDeleted){
                    escapeAudio.PlayOneShot(powerUp, 1f);
                    isDeleted = true;
                    scoreManager.DecreaseScore(detectCollision.scoreToGive);
                    Invoke("DeleteMe", 0.7f);
                }
            } else {
                DeleteMe();
            }
        }
    }

    private void DeleteMe(){
        Debug.Log(tag + " escaped!");
        Destroy(gameObject);
    }
}
