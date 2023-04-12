using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public int scoreToGive;
    public ParticleSystem explosionParticle;
    private ScoreManager scoreManager;

    //audio
    //add hit audio

    public int healthValue = 1;

    void Start(){
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        //explosionAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other){
        
        if(tag != "Pickup"){
            //if hit by an attack, and not a Pickup, decrement health and delete projectile
            if((other.gameObject.CompareTag("Projectile"))&&(tag != "Pickup")){
                healthValue--;

                //play hit audio

                //delete impacting projectile
                Destroy(other.gameObject);

            //if hitting a player, self-destruct AND SHRINK SCORE VALUE
            } else if(other.gameObject.CompareTag("Player")){
                healthValue = 0;
                scoreToGive /= 10;
            }
        } else if(other.gameObject.CompareTag("Player")) {
            healthValue = 0;
        }

        CheckDeath();
    }

    void Explosion(){
        Instantiate(explosionParticle, transform.position, transform.rotation);
    }

    //if out of health, delete UFO
    void CheckDeath(){
        if(healthValue <= 0){

            if(tag != "Pickup"){
                Explosion();
            }

            scoreManager.IncreaseScore(scoreToGive);
            Destroy(this.gameObject);
        }
    }
}