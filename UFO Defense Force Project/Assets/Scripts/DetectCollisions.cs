using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public int healthValue = 1;
    public int scoreToGive;
    //public ParticleSystem explosionParticle;

    void Start(){
        //scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other){
        //if hit by an attack,  decrement health
        if(other.gameObject.CompareTag("Projectile")){
            healthValue--;
            Destroy(other.gameObject);

        //if hitting a player, self-destruct
        } else if(other.gameObject.CompareTag("Player")){
            healthValue = 0;
        }

        CheckDeath();
    }

    void Explosion(){
        //Instantiate(explosionParticle, transform.position, transform.rotation);
    }

    //if out of health, delete UFO
    void CheckDeath(){
        if(healthValue <= 0){
            //Explosion();
            //scoreManager.IncreaseScore(scoreToGive);
            Destroy(this.gameObject);
        }
    }
}