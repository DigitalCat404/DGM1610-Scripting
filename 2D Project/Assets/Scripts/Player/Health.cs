using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int curHealth;
    public float invulDuration = 0.5f;
    private float invulTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        curHealth = maxHealth;
    }

    
    public void TakeDamage(int damage){
        
        if(Time.time > invulTimer + invulDuration){
            curHealth -= damage;
            Debug.Log("Player took " + damage);

            if(curHealth <= 0){
                Time.timeScale = 0;
                Debug.Log("Game over!");
            } else {
                invulTimer = Time.time;
            }
        } else {
            Debug.Log("Protected!");
        }
    }

    
    public void AddHealth(int heal){
        curHealth += heal;

        if(curHealth >= maxHealth){
            curHealth = maxHealth;
        }

        Debug.Log("Player healed " + heal);
    }
}
